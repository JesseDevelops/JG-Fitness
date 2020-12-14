﻿using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Data
{
    public interface IUpload
    {
        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
    }
}
