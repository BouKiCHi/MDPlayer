﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPlayer
{
    public static class Tables
    {
        public static int[] FmFNum = new int[] {
            0x289/8, 0x2af/8, 0x2d8/8, 0x303/8, 0x331/8, 0x362/8, 0x395/8, 0x3cc/8, 0x405/8, 0x443/8, 0x484/8,0x4c8/8,
            0x289/4, 0x2af/4, 0x2d8/4, 0x303/4, 0x331/4, 0x362/4, 0x395/4, 0x3cc/4, 0x405/4, 0x443/4, 0x484/4,0x4c8/4,
            0x289/2, 0x2af/2, 0x2d8/2, 0x303/2, 0x331/2, 0x362/2, 0x395/2, 0x3cc/2, 0x405/2, 0x443/2, 0x484/2,0x4c8/2,
            0x289, 0x2af, 0x2d8, 0x303, 0x331, 0x362, 0x395, 0x3cc, 0x405, 0x443, 0x484, 0x4c8,
            0x289*2, 0x2af*2, 0x2d8*2, 0x303*2, 0x331*2, 0x362*2, 0x395*2, 0x3cc*2, 0x405*2, 0x443*2, 0x484*2,0x4c8*2
        };

        public static int[] PsgFNum = new int[] {
            0x6ae,0x64e,0x5f4,0x59e,0x54e,0x502,0x4ba,0x476,0x436,0x3f8,0x3c0,0x38a, // 0
            0x357,0x327,0x2fa,0x2cf,0x2a7,0x281,0x25d,0x23b,0x21b,0x1fc,0x1e0,0x1c5, // 1
            0x1ac,0x194,0x17d,0x168,0x153,0x140,0x12e,0x11d,0x10d,0x0fe,0x0f0,0x0e3, // 2
            0x0d6,0x0ca,0x0be,0x0b4,0x0aa,0x0a0,0x097,0x08f,0x087,0x07f,0x078,0x071, // 3
            0x06b,0x065,0x05f,0x05a,0x055,0x050,0x04c,0x047,0x043,0x040,0x03c,0x039, // 4
            0x035,0x032,0x030,0x02d,0x02a,0x028,0x026,0x024,0x022,0x020,0x01e,0x01c, // 5
            0x01b,0x019,0x018,0x016,0x015,0x014,0x013,0x012,0x011,0x010,0x00f,0x00e, // 6
            0x00d,0x00d,0x00c,0x00b,0x00b,0x00a,0x009,0x008,0x007,0x006,0x005,0x004  // 7
        };

        public static float[] freqTbl = new float[] {
            261.6255653005986f/8.0f , 277.1826309768721f/8.0f , 293.6647679174076f/8.0f , 311.12698372208087f/8.0f , 329.6275569128699f/8.0f , 349.2282314330039f/8.0f , 369.9944227116344f/8.0f , 391.99543598174927f/8.0f , 415.3046975799451f/8.0f , 440f/8.0f , 466.1637615180899f/8.0f,493.8833012561241f/8.0f,
            261.6255653005986f/4.0f , 277.1826309768721f/4.0f , 293.6647679174076f/4.0f , 311.12698372208087f/4.0f , 329.6275569128699f/4.0f , 349.2282314330039f/4.0f , 369.9944227116344f/4.0f , 391.99543598174927f/4.0f , 415.3046975799451f/4.0f , 440f/4.0f , 466.1637615180899f/4.0f,493.8833012561241f/4.0f,
            261.6255653005986f/2.0f , 277.1826309768721f/2.0f , 293.6647679174076f/2.0f , 311.12698372208087f/2.0f , 329.6275569128699f/2.0f , 349.2282314330039f/2.0f , 369.9944227116344f/2.0f , 391.99543598174927f/2.0f , 415.3046975799451f/2.0f , 440f/2.0f , 466.1637615180899f/2.0f,493.8833012561241f/2.0f,
            261.6255653005986f , 277.1826309768721f , 293.6647679174076f , 311.12698372208087f , 329.6275569128699f , 349.2282314330039f , 369.9944227116344f , 391.99543598174927f , 415.3046975799451f , 440f , 466.1637615180899f,493.8833012561241f,
            261.6255653005986f*2.0f , 277.1826309768721f*2.0f , 293.6647679174076f*2.0f , 311.12698372208087f*2.0f , 329.6275569128699f*2.0f , 349.2282314330039f*2.0f , 369.9944227116344f*2.0f , 391.99543598174927f*2.0f , 415.3046975799451f*2.0f , 440f*2.0f , 466.1637615180899f*2.0f,493.8833012561241f*2.0f,
            261.6255653005986f*4.0f , 277.1826309768721f*4.0f , 293.6647679174076f*4.0f , 311.12698372208087f*4.0f , 329.6275569128699f*4.0f , 349.2282314330039f*4.0f , 369.9944227116344f*4.0f , 391.99543598174927f*4.0f , 415.3046975799451f*4.0f , 440f*4.0f , 466.1637615180899f*4.0f,493.8833012561241f*4.0f,
            261.6255653005986f*8.0f , 277.1826309768721f*8.0f , 293.6647679174076f*8.0f , 311.12698372208087f*8.0f , 329.6275569128699f*8.0f , 349.2282314330039f*8.0f , 369.9944227116344f*8.0f , 391.99543598174927f*8.0f , 415.3046975799451f*8.0f , 440f*8.0f , 466.1637615180899f*8.0f,493.8833012561241f*8.0f,
            261.6255653005986f*16.0f , 277.1826309768721f*16.0f , 293.6647679174076f*16.0f , 311.12698372208087f*16.0f , 329.6275569128699f*16.0f , 349.2282314330039f*16.0f , 369.9944227116344f*16.0f , 391.99543598174927f*16.0f , 415.3046975799451f*16.0f , 440f*16.0f , 466.1637615180899f*16.0f,493.8833012561241f*16.0f
        };

        public static float[] pcmMulTbl = new float[]
        {
            1.0f/2.0f
            ,1.05947557526183f/2.0f
            ,1.122467701246082f/2.0f
            ,1.189205718217262f/2.0f
            ,1.259918966439875f/2.0f
            ,1.334836786178427f/2.0f
            ,1.414226741074841f/2.0f
            ,1.498318171393624f/2.0f
            ,1.587416864154117f/2.0f
            ,1.681828606375659f/2.0f
            ,1.781820961700176f/2.0f
            ,1.887776163901842f/2.0f
            ,1.0f
            ,1.05947557526183f
            ,1.122467701246082f
            ,1.189205718217262f
            ,1.259918966439875f
            ,1.334836786178427f
            ,1.414226741074841f
            ,1.498318171393624f
            ,1.587416864154117f
            ,1.681828606375659f
            ,1.781820961700176f
            ,1.887776163901842f
        };
    }
}