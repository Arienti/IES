using IESUX.Models;

namespace IESInterfaces
{
    public interface IProductBusiness
    {
        ResultDTO Add(ProductDTO productDTO);
        ResultDTO Edit(ProductDTO productDTO);
        ProductsDTO Get();
        ProductsDTO GetByCategoryId(int categoryId);
        ProductsDTO GetById(int Id);
        ResultDTO Delete(ProductDTO productDTO);
        ResultDTO DeleteAll();
    }

}
