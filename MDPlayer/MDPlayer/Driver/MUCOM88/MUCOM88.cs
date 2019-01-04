﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MDPlayer.Driver.MUCOM88
{
    public class MUCOM88 : baseDriver
    {
        /// <summary>
        /// 曲情報取得
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="vgmGd3"></param>
        /// <returns></returns>
        public override GD3 getGD3Info(byte[] buf, uint vgmGd3)
        {
            if (CheckFileType(buf) != enmMUCOMFileType.MUC)
            {
                throw new NotImplementedException();
            }

            List<Tuple<string, string>> tags = GetTagsFromMUC(buf);
            GD3 gd3 = new GD3();
            foreach (Tuple<string, string> tag in tags)
            {
                switch (tag.Item1)
                {
                    case "#title":
                        gd3.TrackName = tag.Item2;
                        gd3.TrackNameJ = tag.Item2;
                        break;
                    case "#composer":
                        gd3.Composer = tag.Item2;
                        gd3.ComposerJ = tag.Item2;
                        break;
                    case "#author":
                        gd3.VGMBy = tag.Item2;
                        break;
                    case "#comment":
                        gd3.Notes = tag.Item2;
                        break;
                    case "#mucom88":
                        gd3.Version = tag.Item2;
                        break;
                    case "#date":
                        gd3.Converted = tag.Item2;
                        break;
                }
            }

            //Debug

            //Compile
            ushort basicsize = StoreBasicSource(buf, 1, 1);

            //MUCOM88 初期化
            muc88.CINT();//0x9600

            //コンパイルコマンドのセット
            z80.HL = 0xf010;
            mem.LD_16(0xf010, 0x41);// 'A'
            mem.LD_16(0xf011, 0x00);
            mem.LD_16(0xf012, 0x00);

            //↓コンパイルが実施される
            int ret = muc88.COMPIL();//vector 0xeea8

            //エラー発生時は0以外が返る
            if (ret != 0)
            {
                int errLine = mem.LD_16(0x0f32e);//ワークアドレスのERRLINE
                log.Write(string.Format("コンパイル時にエラーが発生したみたい(errLine:{0})", errLine));
                return gd3;
            }

            byte[] textLineBuf = new byte[80];
            string msg;

            for (int i = 0; i < 80; i++) textLineBuf[i] = mem.LD_8((ushort)(0xf3c8 + i));
            log.Write(Encoding.GetEncoding("Shift_JIS").GetString(textLineBuf));

            ushort workadr = 0xf320;
            int fmvoice = mem.LD_8((ushort)(workadr + 50));
            int pcmflag = 0;
            int maxcount = 0;
            int mubsize = 0;

            log.Write(string.Format("Used FM voice:{0}", fmvoice));

            string strTcount = "";
            string strLcount = "";
            for (int i = 0; i < muc88.MAXCH[0]; i++)
            {
                int tcnt = mem.LD_16((ushort)(0x8c10 + i * 4));
                int lcnt = mem.LD_16((ushort)(0x8c12 + i * 4));
                if (lcnt != 0) { lcnt = tcnt - (lcnt - 1); }
                if (tcnt > maxcount) maxcount = tcnt;
                msg = Encoding.GetEncoding("Shift_JIS").GetString(new byte[] { (byte)(0x41 + i) });
                strTcount += string.Format("{0}:{1} ", msg, tcnt);
                strLcount += string.Format("{0}:{1} ", msg, lcnt);
            }

            if (mem.LD_16((ushort)(0x8c10 + 10 * 4)) == 0) pcmflag = 2;

            log.Write("[ Total count ]");
            log.Write(strTcount);
            log.Write("");
            log.Write("[ Loop count  ]");
            log.Write(strLcount);
            log.Write("");

            msg = Encoding.GetEncoding("Shift_JIS").GetString(textLineBuf, 31, 4);
            int start = Convert.ToInt32(msg, 16);
            msg = Encoding.GetEncoding("Shift_JIS").GetString(textLineBuf, 41, 4);
            int length = Convert.ToInt32(msg, 16);

            mubsize = length;

            log.Write(string.Format("#Data Buffer ${0:x04}-${1:x04} (${2:x04})", start, start + length - 1, length));
            log.Write(string.Format("#MaxCount:{0} Basic:${1:x04} Data:${2:x04}", maxcount, basicsize, mubsize));

            SaveMusic("test.mub", (ushort)start, (ushort)length, pcmflag);

            return gd3;
        }

        /// <summary>
        /// イニシャライズ
        /// </summary>
        /// <param name="vgmBuf"></param>
        /// <param name="chipRegister"></param>
        /// <param name="model"></param>
        /// <param name="useChip"></param>
        /// <param name="latency"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public override bool init(byte[] vgmBuf, ChipRegister chipRegister, enmModel model, enmUseChip[] useChip, uint latency, uint waitTime)
        {
            throw new NotImplementedException();
        }

        public override void oneFrameProc()
        {
            throw new NotImplementedException();
        }

        public MUCOM88()
        {
            mucInit();
        }



        private ver1_1.expand expand = null;
        private ver1_0.errmsg errmsg = null;
        private ver1_1.msub msub = null;
        private ver1_1.muc88 muc88 = null;
        private ver1_0.ssgdat ssgdat = null;
        private ver1_0.time time = null;
        private ver1_0.smon smon = null;
        private Z80 z80 = null;
        private Mem mem = null;
        private PC88 pc88 = null;

        public enum enmMUCOMFileType
        {
            unknown,
            MUB,
            MUC
        }

        private void mucInit()
        {
            expand = new ver1_1.expand();
            errmsg = new ver1_0.errmsg();
            msub = new ver1_1.msub();
            muc88 = new ver1_1.muc88();
            ssgdat = new ver1_0.ssgdat();
            time = new ver1_0.time();
            smon = new ver1_0.smon();
            z80 = new Z80();
            mem = new Mem();
            pc88 = new PC88();

            expand.Mem = mem;
            expand.Z80 = z80;
            expand.PC88 = pc88;
            expand.msub = msub;
            expand.smon = smon;

            msub.Mem = mem;
            msub.Z80 = z80;
            msub.PC88 = pc88;

            muc88.Mem = mem;
            muc88.Z80 = z80;
            muc88.PC88 = pc88;
            muc88.msub = msub;
            muc88.expand = expand;
            muc88.smon = smon;

            time.Mem = mem;
            time.Z80 = z80;
            time.PC88 = pc88;

            smon.Mem = mem;
            smon.Z80 = z80;
            smon.PC88 = pc88;
            smon.msub = msub;
            smon.expand = expand;

            z80.Mem = mem;

            pc88.Mem = mem;
            pc88.Z80 = z80;

            string fn = "voice.dat";
            LoadFMVoice(fn);

            //ほぼ意味なし
            muc88.CINT();
        }

        private enmMUCOMFileType CheckFileType(byte[] buf)
        {
            if (buf == null || buf.Length < 4)
            {
                return enmMUCOMFileType.unknown;
            }

            if (buf[0] == 0x4d
                && buf[1] == 0x55
                && buf[2] == 0x43
                && buf[3] == 0x38)
            {
                return enmMUCOMFileType.MUB;
            }

            return enmMUCOMFileType.MUC;
        }

        private List<Tuple<string, string>> GetTagsFromMUC(byte[] buf)
        {
            var text = Encoding.GetEncoding("shift_jis").GetString(buf)
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.IndexOf("#") == 0);
            List<Tuple<string, string>> tags = new List<Tuple<string, string>>();

            foreach (string v in text)
            {
                try
                {
                    Tuple<string, string> item = new Tuple<string, string>(v.Substring(0, v.IndexOf(' ')).ToLower(), v.Substring(v.IndexOf(' ') + 1));
                    tags.Add(item);
                }
                catch { }
            }

            return tags;
        }

        private ushort StoreBasicSource(byte[] buf, int line, int add)
        {
            var text = Encoding.GetEncoding("shift_jis").GetString(buf)
                .Split(new string[] { "\r\n" }, StringSplitOptions.None);

            ushort mptr = 1;
            ushort linkptr = mptr;
            foreach (string txt in text)
            {
                byte[] data = Encoding.GetEncoding("shift_jis").GetBytes(txt.Replace("\x09", " "));
                linkptr = mptr;
                mptr += 2;
                mem.LD_16(mptr, (ushort)line);
                mptr += 2;
                mem.LD_8(mptr++, 0x3a);
                mem.LD_8(mptr++, 0x8f);
                mem.LD_8(mptr++, 0xe9);
                foreach (byte b in data) mem.LD_8(mptr++, b);
                mem.LD_8(mptr++, 0);
                mem.LD_16(linkptr, (ushort)mptr);
                line += add;
            }
            mem.LD_16(linkptr, (ushort)0);

            return mptr;
        }

        private int SaveMusic(string fname, ushort start, ushort length, int option)
        {
            //		音楽データファイルを出力(コンパイルが必要)
            //		filename     = 出力される音楽データファイル
            //		option : 1   = #タグによるvoice設定を無視
            //		         2   = PCM埋め込みをスキップ
            //		(戻り値が0以外の場合はエラー)
            //

            List<byte> dat = new List<byte>();
            ushort footsize;
            ushort pcmptr;
            ushort pcmsize;

            if (string.IsNullOrEmpty(fname)) return -1;

            footsize = 1;//かならず1以上
            pcmptr = (ushort)(((option & 2) != 0) ? 0 : (32 + length + footsize));
            pcmsize = 0;
            //if (infobuf)
            //{
            //    infobuf->Put((int)0);
            //    footer = infobuf->GetBuffer();
            //    footsize = infobuf->GetSize();
            //}

            dat.Add(0x4d);// M
            dat.Add(0x55);// U
            dat.Add(0x43);// C
            dat.Add(0x38);// 8
            dat.Add(32); //header size(32bit)
            dat.Add(0);
            dat.Add(0);
            dat.Add(0);
            dat.Add((byte)length);//data size(32bit)
            dat.Add((byte)(length >> 8));
            dat.Add((byte)(length >> 16));
            dat.Add((byte)(length >> 24));
            dat.Add((byte)(32 + length));//tagdata ptr(32bit)
            dat.Add((byte)((32 + length) >> 8));
            dat.Add((byte)((32 + length) >> 16));
            dat.Add((byte)((32 + length) >> 24));
            dat.Add((byte)footsize);//tagdata size(32bit)
            dat.Add((byte)(footsize >> 8));
            dat.Add((byte)(footsize >> 16));
            dat.Add((byte)(footsize >> 24));
            dat.Add((byte)pcmptr);//pcmdata ptr(32bit)
            dat.Add((byte)(pcmptr >> 8));
            dat.Add((byte)(pcmptr >> 16));
            dat.Add((byte)(pcmptr >> 24));
            dat.Add((byte)pcmsize);//pcmdata size(32bit)
            dat.Add((byte)(pcmsize >> 8));
            dat.Add((byte)(pcmsize >> 16));
            dat.Add((byte)(pcmsize >> 24));
            dat.Add((byte)mem.LD_16(0x8c90));// JCLOCKの値(Jコマンドのタグ位置)
            dat.Add((byte)(mem.LD_16(0x8c90) >> 8));
            dat.Add((byte)(mem.LD_16(0x8c90) >> 16));
            dat.Add((byte)(mem.LD_16(0x8c90) >> 24));

            if (mem.LD_16(0x8c90) > 0)
            {
                log.Write(string.Format("#Jump count [{0}].\r\n", mem.LD_16(0x8c90)));
            }

            for (int i = 0; i < length; i++) dat.Add(mem.LD_8((ushort)(start + i)));

            //for (int i = 0; i < footsize; i++) dat.Add(0);

            if ((option & 2) == 0)
            {
                //for (int i = 0; i < pcmsize; i++) dat.Add(0);
            }

            try
            {
                System.IO.File.WriteAllBytes(fname, dat.ToArray());
            }
            catch
            {
                log.Write(string.Format("#File write error [{0}].\r\n", fname));
                return -2;
            }

            log.Write(string.Format("#Saved [{0}].\r\n", fname));
            return 0;
        }

        private void LoadFMVoice(string fn)
        {
            if(!File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fn)))
            {
                return;
            }

            try
            {
                byte[] voice = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fn));
                ushort adr = 0x6000;
                foreach (byte b in voice)
                {
                    mem.LD_8(adr++, b);
                }
            }
            catch
            {
                //失敗しても特に何もしない
            }
        }
    }
}
