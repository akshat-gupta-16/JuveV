﻿using DataAccess.Contracts;
using DataAccess.Domain;

namespace DataAccess.Repos
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
    }
}
