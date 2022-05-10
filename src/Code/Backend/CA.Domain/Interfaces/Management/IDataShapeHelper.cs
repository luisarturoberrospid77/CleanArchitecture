using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Management
{
    public interface IDataShapeHelper<T>
    {
        ShapedEntityDTO ShapeData(T entity, string fieldsString);
        IEnumerable<ShapedEntityDTO> ShapeData(IEnumerable<T> entities, string fieldsString);
        Task<IEnumerable<ShapedEntityDTO>> ShapeDataAsync(IEnumerable<T> entities, string fieldsString);
    }
}
