using System;

namespace TomLabs.Shadowgem.Text.Encription
{
	/// <summary>
	/// Provides methods for string encryption/decryption
	/// </summary>
	public static class StringEncrypt
	{
		/// <summary>
		/// Encrypts a string using the supplied key. Encoding is done using RSA encryption.
		/// </summary>
		/// <param name="stringToEncrypt">String that must be encrypted.</param>
		/// <param name="key">EncryptionKey.</param>
		/// <returns>A string representing a byte array separated by a minus sign.</returns>
		/// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
		public static string Encrypt(this string stringToEncrypt, string key)
		{
			if (stringToEncrypt.IsNullOrEmpty())
				throw new ArgumentException("An empty string value cannot be encrypted.", nameof(stringToEncrypt));
			if (key.IsNullOrEmpty())
				throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.", nameof(key));

			System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
			cspp.KeyContainerName = key;

			System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
			rsa.PersistKeyInCsp = true;

			byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);

			return BitConverter.ToString(bytes);
		}

		/// <summary>
		/// Decrypts a string using the supplied key. Decoding is done using RSA encryption.
		/// </summary>
		/// <param name="key">DecryptionKey.</param>
		/// <returns>The decrypted string or null if decryption failed.</returns>
		/// <param name="stringToDecrypt"></param>
		/// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
		public static string Decrypt(this string stringToDecrypt, string key)
		{
			if (stringToDecrypt.IsNullOrEmpty())
				throw new ArgumentException("An empty string value cannot be encrypted.", nameof(stringToDecrypt));
			if (key.IsNullOrEmpty())
				throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.", nameof(key));

			string result = null;
			try
			{
				System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
				cspp.KeyContainerName = key;

				System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
				rsa.PersistKeyInCsp = true;

				string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
				byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));

				byte[] bytes = rsa.Decrypt(decryptByteArray, true);

				result = System.Text.UTF8Encoding.UTF8.GetString(bytes);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return result;
		}
	}
}