# About RSA Gui App 

This application was developed with .NET Framework 4.7.2 and it is very easy to use encrypt and decrypt texts using the RSA algorithm.

For the algorithm `Cryptography` **[library](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=netframework-4.7.2)** used.

## Overview of application
<img src="https://yavuzselimkismetli.com/rsa/rsa_1.jpg" alt="Overview" style="width: 40%; height: 40%"/>

## Options about key size

- 1024 bits
- 2048 bits
- 4096 bits

You can choose an option for creating keys.

<img src="https://yavuzselimkismetli.com/rsa/rsa_2.jpg" alt="Key selecting" style="width: 40%; height: 40%"/>

  
## Encryption

To encrypt texts or sentences, you must first create a public key and a private key. When the application starts, the keys (1024 bits) are generated automatically.
Then you choose an option for the key length and wait for the program to generate the keys. The keys are generated successfully and you can enter your word/phrase in the Plain Text area and then click the Encrypt button.

The encryption method `Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding, int KeyLen)`. This requires the key length, the RSA key (public/private) and `Data` as `byte[]` type.

## Decryption

Decrypt your text by entering the sentence in the "Encrypted Text" area and pressing the "Decrypt" button.

The decryption method `Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding, int KeyLen)` has the same requirements as the `Encryption()` method.

<img src="https://yavuzselimkismetli.com/rsa/rsa_3.jpg" alt="Encryption and Decryption" style="width: 60%; height: 60%"/>

## Usage

Download the repo and open `RSAGuiApp.sln (built with VS2019)` and then just run it.

### Note
> _If you use a different key than the one used in the app, it won't be decrypted (e.g. if you keep the key before you used it and you think you'll use it later in the app, it won't work)._
