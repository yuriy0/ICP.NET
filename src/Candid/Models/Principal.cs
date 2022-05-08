﻿using ICP.Candid.Crypto;
using System;
using System.Linq;

namespace ICP.Candid.Models
{
	public class PrincipalId : IHashable, IEquatable<PrincipalId>
    {
        private const byte anonymousSuffix = 4;
        private const byte selfAuthenticatingSuffix = 4;

        public byte[] Raw { get; }
        public PrincipalId(byte[] raw)
        {
            this.Raw = raw;
        }

        public string ToText()
        {
            // Add checksum to beginning of byte array;
            var crc32 = new CRC32();
            byte[] checksum = crc32.ComputeHash(this.Raw);
            byte[] bytesWithChecksum = checksum.Concat(this.Raw).ToArray();
            string base32String = Base32EncodingUtil.ToString(bytesWithChecksum);
            base32String = base32String.Trim('=');

            // Add a dash every 5 characters
            int dashCount = base32String.Length / 5;
            char[] chars = new char[base32String.Length + dashCount];
            int offset = 0;
            for (int i = 0; i < base32String.Length; i++)
            {
                if (i % 5 == 0 && i != 0)
                {
                    chars[i + offset] = '-';
                    offset += 1;
                }
                chars[i + offset] = base32String[i];
            }
            return new string(chars);
        }

        public override string ToString()
        {
            return this.ToText();
        }

        public string ToHex()
        {
            return Convert.ToHexString(this.Raw);
        }

        public bool IsAnonymous()
        {
            return this.Raw.Length == 1 && this.Raw[0] == anonymousSuffix;
        }

        public static PrincipalId ICManagementCanisterId()
		{
            return new PrincipalId(new byte[0]);
		}

        public static PrincipalId FromHex(string hex)
        {
            byte[] bytes = Convert.FromHexString(hex.AsSpan());
            return new PrincipalId(bytes);
        }

        public static PrincipalId Anonymous()
        {
            return new PrincipalId(new byte[] { anonymousSuffix });
        }

        public static PrincipalId SelfAuthenticating(byte[] publicKey)
        {
            byte[] digest = new SHA224().GenerateDigest(publicKey);

            // bytes = digest + selfAuthenticatingSuffix
            byte[] bytes = new byte[digest.Length + 1];
            digest.CopyTo(bytes.AsSpan());
            bytes[^1] = selfAuthenticatingSuffix;
            return new PrincipalId(bytes);
        }

        public static PrincipalId FromText(string text)
        {
            string canisterIdNoDash = text
                .ToLower()
                .Replace("-", "");

            byte[] bytes = Base32EncodingUtil.ToBytes(canisterIdNoDash);

            // Remove first 4 bytes which is the checksum
            bytes = bytes
                .AsSpan()
                .Slice(4)
                .ToArray();

            var principal = new PrincipalId(bytes);
            string parsedText = principal.ToText();
            if (parsedText != text)
            {
                throw new Exception($"Principal '${parsedText}' does not have a valid checksum.");
            }

            return principal;
        }

        public static PrincipalId FromRaw(byte[] raw)
        {
            // TODO any validation?
            return new PrincipalId(raw);
        }

        public byte[] ComputeHash(IHashFunction hashFunction)
        {
            return hashFunction.ComputeHash(this.Raw);
        }

        public bool Equals(PrincipalId? other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Raw.SequenceEqual(other.Raw);
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as PrincipalId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Raw);
        }
    }
}