using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //table rename
            ToTable("tbl_Course");

            //primary keys

            HasKey(x => x.Id);

            //Props

            //Relathions
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);

            HasRequired(x => x.Author)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Tags)
                .WithMany(x => x.Courses)
                .Map(x =>
                {
                    x.ToTable("CourseTags");
                    x.MapLeftKey("CourseId");
                    x.MapRightKey("TagId");
                });

            HasRequired(x => x.Cover)
                .WithRequiredPrincipal(x => x.Course);

        }
    }
}
