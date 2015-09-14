# How to enable DEBUG in a developer environment
You need to disable Strong-Name Verification, when you want to change the code and debug it.
When you use NuGET, these steps are not needed.

Since the project is using the delay-signing with only the public key, .NET CLR assembly verification will fail with assemblies built locally. When the verification fails you won’t be able to run or debug the assemblies.

To overcome this in development, you need to disable strong-name verification for assemblies that you build locally and delay-sign with your public key.

Run the flowing command as Administrator:
```
sn -Vr *,12c39828a76d120f
```

This will disable strong name verification for all assemblies signed with your public key. You can list current settings for strong name verification with: 

```
sn -Vl
```