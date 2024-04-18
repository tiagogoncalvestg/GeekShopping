﻿using Microsoft.EntityFrameworkCore;

namespace Store.ProductApi.Infrastructure.Context;

public class AppContext : DbContext
{

    public AppContext() { }
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }
}
