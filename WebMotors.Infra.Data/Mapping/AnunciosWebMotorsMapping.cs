using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;

namespace WebMotors.Infra.Data.Mapping
{
    public class AnunciosWebMotorsMapping : EntityTypeConfiguration<AnunciosWebMotors>
    {
        public AnunciosWebMotorsMapping()
        {
            ToTable("tb_AnuncioWebmotors");
            HasKey(x => x.ID);
            Property(x => x.Marca).IsRequired().HasMaxLength(45);
            Property(x => x.Modelo).IsRequired().HasMaxLength(45);
            Property(x => x.Versao).IsRequired().HasMaxLength(45);
        }
    }
}
