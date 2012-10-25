using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOrder
{
    public class ByteBuilder
    {
        byte[] data;
        int count;
        public int Count { get { return count; } }
        public byte[] Data { get { return data; } }
        Encoding DefaultEncoding = Encoding.UTF8;
        public ByteBuilder(int Capacity)
        {
            data = new byte[Capacity];
            count = 0;
        }
        public ByteBuilder()
        {
            data = new byte[256];
            count = 0;
        }
        public void SetEncoding(Encoding encoding)
        {
            DefaultEncoding = encoding;
        }

        public byte[] ToBytes() { byte[] buf = new byte[count]; Array.Copy(data, buf, count); return buf; }
        public override string ToString()
        {
            return DefaultEncoding.GetString(data, 0, count);
        }
        public string ToString(Encoding encoding)
        {
            return encoding.GetString(data, 0, count);
        }
        public void Append(byte b)
        {
            if (count >= data.Length)
            {
                int newCapa = data.Length * 2;
                byte[] newData = new byte[newCapa];
                Array.Copy(data, newData, count);
                data = newData;
            }
            data[count++] = b;
        }
        public void Append(ushort u)        // 按網路規距,HiOrder在前
        {
            Append((byte)(u / 256));
            Append((byte)(u % 256));
        }
        public void Append(string s)
        {
            if (s != null)
                Append(DefaultEncoding.GetBytes(s));
        }

        public void Append(string s, Encoding encoding)
        {
            if (s != null)
                Append(encoding.GetBytes(s));
        }
        public void AppendPadRight(String s, int len, Encoding encoding)
        {
            if (s.Length > len) s = s.Substring(0, len);
            Append(s.PadRight(len), encoding);
        }

        public void AppendPadLeft(String s, int len, Encoding encoding)
        {
            if (s.Length > len) s = s.Substring(0, len);
            Append(s.PadLeft(len), encoding);
        }

        public void Append(byte[] buf)
        {
            if (buf != null)
                Append(buf, 0, buf.Length);
        }
        public void Append(byte[] buf, int begin, int len)
        {
            if (len > 1024 * 512) return;  // 太大了，不處理
            int newLen = count + len;
            if (newLen < data.Length)
            {
                Array.Copy(buf, begin, data, count, len);
                count = newLen;
                return;
            }
            int newCapa = data.Length * 2;
            for (; newLen > newCapa; newCapa *= 2) ;
            if (newCapa > 1024 * 1024) return;   // 大於1M了，不處理
            byte[] newData = new byte[newCapa];
            Array.Copy(data, newData, count);
            Array.Copy(buf, begin, newData, count, len);
            count = newLen;
            data = newData;
        }

        public static bool Match(byte[] buf, byte[] buf1)
        {
            if (buf.Length != buf1.Length) return false;
            int n = buf.Length;
            for (int i = 0; i < n; i++)
                if (buf[i] != buf1[i]) return false;
            return true;
        }
        public static bool Match(byte[] buf, byte[] buf1, int count)
        {
            if (buf.Length < count) return false;
            if (buf1.Length < count) return false;
            for (int i = 0; i < count; i++)
                if (buf[i] != buf1[i]) return false;
            return true;
        }

    }
}
