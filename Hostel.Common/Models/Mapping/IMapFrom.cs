using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Common.Models.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
