﻿using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewSector
    {		
		Int64 Id{ get; set; }
		Int64 ReviewId{ get; set; }
		Int64 SectorId{ get; set; }

		Models.Review Review { get; set; }
		Models.Sector Sector { get; set; }

    }
}