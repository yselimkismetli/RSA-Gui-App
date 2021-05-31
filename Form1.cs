using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RSAGuiApp
{
    public partial class Form1 : Form
    {

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA;

        byte[] plainText;
        byte[] encryptedtext;

        public Form1()
        {
            InitializeComponent();
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding, int KeyLen)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(KeyLen))
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding, int KeyLen)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(KeyLen))
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(1024);
            comboBox1.Items.Add(2048);
            comboBox1.Items.Add(4096);

            comboBox1.SelectedIndex = 0;

            RSA = new RSACryptoServiceProvider(RSAGetKLen(comboBox1.SelectedIndex));

            txtEncrypted.ScrollBars = ScrollBars.Vertical;
            txtDecrypted.ScrollBars = ScrollBars.Vertical;
            txtPrivKey.ScrollBars = ScrollBars.Vertical;
            txtPubKey.ScrollBars = ScrollBars.Vertical;
        }


        public static int RSAGetKLen(int cb = -1)
        {
            int RSAKLen = 0;

            if (cb == 0)
            {
                RSAKLen = 1024;
            }
            else if (cb == 1)
            {
                RSAKLen = 2048;
            }
            else if (cb == 2)
            {
                RSAKLen = 4096;
            }

            return RSAKLen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int RSAKLen = 0;
            RSAKLen = RSAGetKLen(comboBox1.SelectedIndex);

            plainText = ByteConverter.GetBytes(txtPlain.Text);

            encryptedtext = Encryption(plainText, RSA.ExportParameters(false), false, RSAKLen);
            txtEncrypted.Text = Convert.ToBase64String(encryptedtext);

            progressBar1.Value = 0;
            progressBar1.Step = 10;
            for (int i = 0; i < 100; i++)
            {
                progressBar1.PerformStep();
                Application.DoEvents();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RSAKLen = 0;
            RSAKLen = RSAGetKLen(comboBox1.SelectedIndex);

            byte[] decryptedtext = Decryption(encryptedtext, RSA.ExportParameters(true), false, RSAKLen);
            txtDecrypted.Text = ByteConverter.GetString(decryptedtext);

            progressBar1.Value = 0;
            progressBar1.Step = 25;
            for (int i = 0; i < 100; i++)
            {
                progressBar1.PerformStep();
                Application.DoEvents();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            RSA = new RSACryptoServiceProvider(RSAGetKLen(Convert.ToInt32(selectedIndex)));

            var privKey = RSA.ToXmlString(true);
            var pubKey = RSA.ToXmlString(false);

            txtPubKey.Text = pubKey;
            txtPrivKey.Text = privKey;
        }

     
    }
}
