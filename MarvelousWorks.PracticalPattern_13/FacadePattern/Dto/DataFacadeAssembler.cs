using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Dto
{
    public class DataFacadeAssembler
    {
        /// <summary>
        /// 实际的过程可能非常复杂，Assembler需要通过各种本地或远程方法
        /// 获得一个 DTO 对象接口的引用，而且考虑到效率因素，DTO 本身应该相对
        /// 客户程序而言，到实际外观对象更近，否则DTO的“打包”反而成为累赘。
        /// </summary>
        /// <returns></returns>
        public IXmlDataDto CreateDto(IDataFacade facade)
        {
            if (facade == null) throw new ArgumentNullException("facade");
            IXmlDataDto dto = new XmlDataDto();
            dto.Facade = facade;
            return dto;
        }
    }
}
