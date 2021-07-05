using System;
using System.Security.Cryptography;
using System.Text;

namespace recipe_api.Services
{
	public class HashService: IHashService
	{
		private readonly string SecurityKey;

		public HashService(string securityKey)
		{
			SecurityKey = securityKey;
		}

		public string DecryteString(string cryptedText)
		{
			byte[] toEncryptArray = Convert.FromBase64String(cryptedText);
			MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
			byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));

			objMD5CryptoService.Clear();

			TripleDESCryptoServiceProvider objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
			objTripleDESCryptoService.Key = securityKeyArray;
			objTripleDESCryptoService.Mode = CipherMode.ECB;
			objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

			var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
			byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			objTripleDESCryptoService.Clear();

			return UTF8Encoding.UTF8.GetString(resultArray);
		}

		public string HashString(string text)
		{
			Console.WriteLine(SecurityKey);
			byte[] toByteArray = UTF8Encoding.UTF8.GetBytes(text);
			MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
			byte[] securityKeyBytes = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));

			objMD5CryptoService.Clear();

			TripleDESCryptoServiceProvider objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
			objTripleDESCryptoService.Key = securityKeyBytes;
			objTripleDESCryptoService.Mode = CipherMode.ECB;
			objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

			var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
			byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toByteArray, 0, toByteArray.Length);

			objTripleDESCryptoService.Clear();

			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
	}
}
