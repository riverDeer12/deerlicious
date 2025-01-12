using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deerlicious.API.Database.Configurations;

public class RecipeCategoryConfiguration : IEntityTypeConfiguration<RecipeCategory>
{
    public void Configure(EntityTypeBuilder<RecipeCategory> builder)
    {
        builder.HasKey(bc => new { bc.RecipeId, bc.CategoryId });

        builder
            .HasOne(bc => bc.Recipe)
            .WithMany(b => b.Categories)
            .HasForeignKey(bc => bc.RecipeId);

        builder
            .HasOne(bc => bc.Category)
            .WithMany(c => c.Recipes)
            .HasForeignKey(bc => bc.CategoryId);
    }
}