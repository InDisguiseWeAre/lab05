using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static uint[] table = {
            252, 238, 221,  17, 207, 110,  49,  22,
            251, 196, 250, 218,  35, 197,   4,  77,
            233, 119, 240, 219, 147,  46, 153, 186,
             23,  54, 241, 187,  20, 205,  95, 193,
            249,  24, 101,  90, 226,  92, 239,  33,
            129,  28,  60,  66, 139,   1, 142,  79,
              5, 132,   2, 174, 227, 106, 143, 160,
              6,  11, 237, 152, 127, 212, 211,  31,
            235,  52,  44,  81, 234, 200,  72, 171,
            242,  42, 104, 162, 253,  58, 206, 204,
            181, 112,  14,  86,   8,  12, 118,  18,
            191, 114,  19,  71, 156, 183,  93, 135,
             21, 161, 150,  41,  16, 123, 154, 199,
            243, 145, 120, 111, 157, 158, 178, 177,
             50, 117,  25,  61, 255,  53, 138, 126,
            109,  84, 198, 128, 195, 189,  13,  87,
            223, 245,  36, 169,  62, 168,  67, 201,
            215, 121, 214, 246, 124,  34, 185,   3,
            224,  15, 236, 222, 122, 148, 176, 188,
            220, 232,  40,  80,  78,  51,  10,  74,
            167, 151,  96, 115,  30,   0,  98,  68,
             26, 184,  56, 130, 100, 159,  38,  65,
            173,  69,  70, 146,  39,  94,  85,  47,
            140, 163, 165, 125, 105, 213, 149,  59,
              7,  88, 179,  64, 134, 172,  29, 247,
             48,  55, 107, 228, 136, 217, 231, 137,
            225,  27, 131,  73,  76,  63, 248, 254,
            141,  83, 170, 144, 202, 216, 133,  97,
             32, 113, 103, 164,  45,  43,   9,  91,
            203, 155,  37, 208, 190, 229, 108,  82,
             89, 166, 116, 210, 230, 244, 180, 192,
            209, 102, 175, 194,  57,  75,  99, 182
        };
        static uint[] reverse_table = {
    0xA5, 0x2D, 0x32, 0x8F, 0x0E, 0x30, 0x38, 0xC0,
    0x54, 0xE6, 0x9E, 0x39, 0x55, 0x7E, 0x52, 0x91,
    0x64, 0x03, 0x57, 0x5A, 0x1C, 0x60, 0x07, 0x18,
    0x21, 0x72, 0xA8, 0xD1, 0x29, 0xC6, 0xA4, 0x3F,
    0xE0, 0x27, 0x8D, 0x0C, 0x82, 0xEA, 0xAE, 0xB4,
    0x9A, 0x63, 0x49, 0xE5, 0x42, 0xE4, 0x15, 0xB7,
    0xC8, 0x06, 0x70, 0x9D, 0x41, 0x75, 0x19, 0xC9,
    0xAA, 0xFC, 0x4D, 0xBF, 0x2A, 0x73, 0x84, 0xD5,
    0xC3, 0xAF, 0x2B, 0x86, 0xA7, 0xB1, 0xB2, 0x5B,
    0x46, 0xD3, 0x9F, 0xFD, 0xD4, 0x0F, 0x9C, 0x2F,
    0x9B, 0x43, 0xEF, 0xD9, 0x79, 0xB6, 0x53, 0x7F,
    0xC1, 0xF0, 0x23, 0xE7, 0x25, 0x5E, 0xB5, 0x1E,
    0xA2, 0xDF, 0xA6, 0xFE, 0xAC, 0x22, 0xF9, 0xE2,
    0x4A, 0xBC, 0x35, 0xCA, 0xEE, 0x78, 0x05, 0x6B,
    0x51, 0xE1, 0x59, 0xA3, 0xF2, 0x71, 0x56, 0x11,
    0x6A, 0x89, 0x94, 0x65, 0x8C, 0xBB, 0x77, 0x3C,
    0x7B, 0x28, 0xAB, 0xD2, 0x31, 0xDE, 0xC4, 0x5F,
    0xCC, 0xCF, 0x76, 0x2C, 0xB8, 0xD8, 0x2E, 0x36,
    0xDB, 0x69, 0xB3, 0x14, 0x95, 0xBE, 0x62, 0xA1,
    0x3B, 0x16, 0x66, 0xE9, 0x5C, 0x6C, 0x6D, 0xAD,
    0x37, 0x61, 0x4B, 0xB9, 0xE3, 0xBA, 0xF1, 0xA0,
    0x85, 0x83, 0xDA, 0x47, 0xC5, 0xB0, 0x33, 0xFA,
    0x96, 0x6F, 0x6E, 0xC2, 0xF6, 0x50, 0xFF, 0x5D,
    0xA9, 0x8E, 0x17, 0x1B, 0x97, 0x7D, 0xEC, 0x58,
    0xF7, 0x1F, 0xFB, 0x7C, 0x09, 0x0D, 0x7A, 0x67,
    0x45, 0x87, 0xDC, 0xE8, 0x4F, 0x1D, 0x4E, 0x04,
    0xEB, 0xF8, 0xF3, 0x3E, 0x3D, 0xBD, 0x8A, 0x88,
    0xDD, 0xCD, 0x0B, 0x13, 0x98, 0x02, 0x93, 0x80,
    0x90, 0xD0, 0x24, 0x34, 0xCB, 0xED, 0xF4, 0xCE,
    0x99, 0x10, 0x44, 0x40, 0x92, 0x3A, 0x01, 0x26,
    0x12, 0x1A, 0x48, 0x68, 0xF5, 0x81, 0x8B, 0xC7,
    0xD6, 0x20, 0x0A, 0x08, 0x00, 0x4C, 0xD7, 0x74
};

        static byte[][] k =
            {
        new byte[] {0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 },
        new byte[] {0xfe, 0xdc, 0xba, 0x98, 0x76, 0x54, 0x32, 0x10, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef },
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
        new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}
        };
        static byte[] c = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        static void Main(string[] args)
        {
            byte[] b = { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x00, 0xff, 0xee, 0xdd, 0xcc, 0xbb, 0xaa, 0x99, 0x88 };
            EN(b);
            for (int i = 0; i < b.Count(); i++)
            {
                Console.Write(b[i].ToString("X2"));
            }
            Console.WriteLine();
            DE(b);
            for (int i = 0; i < b.Count(); i++)
            {
                Console.Write(b[i].ToString("X2"));
            }
            byte[] byt = Encoding.UTF8.GetBytes(File.ReadAllText("first.txt"));
            if (byt.Length % 16 != 0)
            {
                Array.Resize(ref byt, byt.Length + (16 - byt.Length % 16));

            }
            var bloc = new byte[16];
            var result = new byte[byt.Length];
            for (int i = 0; i < byt.Length / 16; i++)
            {
                Array.Copy(byt, 16 * i, bloc, 0, 16);
                Array.Copy(EN(bloc), 0, result, 16 * i, 16);
            }
            File.WriteAllBytes("third.txt", result);


            byt = File.ReadAllBytes("third.txt");
            if (byt.Length % 16 != 0)
            {
                Array.Resize(ref byt, byt.Length + (16 - byt.Length % 16));

            }
            bloc = new byte[16];
            result = new byte[byt.Length];
            for (int i = 0; i < byt.Length / 16; i++)
            {
                Array.Copy(byt, 16 * i, bloc, 0, 16);
                Array.Copy(DE(bloc), 0, result, 16 * i, 16);
            }
            File.WriteAllBytes("second.txt", result);

        }

        static byte Mul(byte a, byte b)
        {
            byte c = 0;
            byte hi_bit_set = 0;
            for (int i = 0; i < 8 && b != 0; i++)
            {

                if ((b & 1) == 1) c ^= a;
                hi_bit_set = (byte)(a & 0x80);
                a <<= 1;
                if (hi_bit_set != 0) a ^= 0xc3;
                b >>= 1;
            }
            return c;
        }



        static byte Invers(byte a)
        {

            byte b = a;
            for (int i = 0; i < 253; i++)
            {
                b = Mul(b, a);
            }
            return b;
        }


        private static byte[] X(byte[] a, byte[] k)
        {
            for (int i = 0; i < 16; i++)
            {
                a[i] ^= k[i];
            }
            return a;
        }



        private static byte[] S(byte[] b)
        {
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(1 + " " + b[i].ToString("X2"));
                b[i] = (byte)table[b[i]];
                Console.WriteLine(2 + " " + b[i]);
            }
            return b;
        }

        private static byte[] S1(byte[] b)
        {
            for (int i = 0; i < 16; i++)
            {
                b[i] = (byte)reverse_table[b[i]];
            }
            return b;
        }
        private static byte[] R(byte[] b)
        {
            byte x = l(b), y, z;
            z = b[15];
            for (int i = 15; i > 0; i--)
            {
                y = b[i - 1];
                b[i - 1] = z;
                z = y;

            }
            b[15] = x;
            z = b[0];
            for (int i = 0; i < 15; i++)
            {
                y = b[i + 1];
                b[i + 1] = z;
                z = y;

            }
            b[0] = x;
            return b;
        }



        private static byte[] R1(byte[] b)
        {
            byte x = b[0], y, z;
            z = b[15];
            for (int i = 15; i > 0; i--)
            {
                y = b[i - 1];
                b[i - 1] = z;
                z = y;

            }
            b[15] = x;
            b[15] = l(b);
            return b;
        }
        private static byte l(byte[] b)
        {

            return (byte)(Mul(148, b[0]) ^ Mul(32, b[1]) ^ Mul(133, b[2]) ^ Mul(16, b[3]) ^ Mul(194, b[4]) ^ Mul(192, b[5]) ^ Mul(1, b[6]) ^ Mul(251, b[7]) ^ Mul(1, b[8]) ^ Mul(192, b[9]) ^ Mul(194, b[10]) ^ Mul(16, b[11]) ^ Mul(133, b[12]) ^ Mul(32, b[13]) ^ Mul(148, b[14]) ^ Mul(1, b[15]));
           // return (byte)(Mul(148, b[15]) ^ Mul(32, b[14]) ^ Mul(133, b[13]) ^ Mul(16, b[12]) ^ Mul(194, b[11]) ^ Mul(192, b[10]) ^ Mul(1, b[9]) ^ Mul(251, b[8]) ^ Mul(1, b[7]) ^ Mul(192, b[6]) ^ Mul(194, b[5]) ^ Mul(16, b[4]) ^ Mul(133, b[3]) ^ Mul(32, b[2]) ^ Mul(148, b[1]) ^ Mul(1, b[0]));
        }



        private static byte[] L(byte[] b)
        {
            for (int i = 0; i < 16; i++)
            {
                b = R(b);
            }
            return b;
        }

        private static byte[] L1(byte[] b)
        {
            for (int i = 0; i < 16; i++)
            {
                b = R1(b);
            }
            return b;
        }
        private static void K()
        {

            for (int i = 1; i <= 4; i++)
            {
                byte[] k1 = new byte[16], k2 = new byte[16];
                Array.Copy(k[i * 2 - 2], k1, 16);
                Array.Copy(k[i * 2 - 1], k2, 16);
                F(i, k1, k2);
            }
        }

        private static void F(int x, byte[] k1, byte[] k2)
        {

            for (int i = 1; i < 9; i++)
            {
                c[15] = (byte)(8 * (x - 1) + i);
                byte[] y = new byte[k1.Count()], c1 = new byte[16];
                Array.Copy(k1, y, k1.Count());
                Array.Copy(c, c1, c.Count());
                k1 = L(S(X(k1, L(c1))));
                k1 = X(k1, k2);
                k2 = y;
            }

            k[2 * x] = k1;
            k[2 * x + 1] = k2;
        }
        private static byte[] EN(byte[] b)
        {
            K();
            for (int i = 0; i < 10; i++)
            {
                if (i != 9)
                    b = L(S(X(b, k[i])));
                else
                    b = X(b, k[i]);
            }
            return b;
        }


        private static byte[] DE(byte[] b)
        {
            K();
            for (int i = 9; i >= 0; i--)
            {
                if (i != 0)
                    b = S1(L1(X(b, k[i])));
                else
                    b = X(b, k[i]);
            }
            return b;
        }
    }
}
