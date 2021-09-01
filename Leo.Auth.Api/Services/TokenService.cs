﻿using AuthJWT.WebAPI.Configurations;
using AuthJWT.WebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJWT.WebAPI.Services
{
    public static class TokenService
    {
        public static UserViewModel GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserViewModel
            {
                Username = user.Username,
                IsAuthenticaded = true,
                Token = tokenHandler.WriteToken(token),
                ExpiresIn = tokenDescriptor.Expires.Value
            };
        }
    }
}
