﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Diagnostic_Medical_Center
{
    public static class Cryto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography
                    .SHA256.Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(value)));
        } 
    }
}