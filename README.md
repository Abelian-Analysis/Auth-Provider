# Auth Providor

This is a Single Sign On (SSO) auth providor that will privde Users with a
RSA-Sha256 Signed Json Web Token. 

# Setup

You will first have to create the database 
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
