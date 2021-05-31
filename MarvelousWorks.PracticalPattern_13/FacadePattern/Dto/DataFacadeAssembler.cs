using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Dto
{
    public class DataFacadeAssembler
    {
        /// <summary>
        /// ʵ�ʵĹ��̿��ܷǳ����ӣ�Assembler��Ҫͨ�����ֱ��ػ�Զ�̷���
        /// ���һ�� DTO ����ӿڵ����ã����ҿ��ǵ�Ч�����أ�DTO ����Ӧ�����
        /// �ͻ�������ԣ���ʵ����۶������������DTO�ġ������������Ϊ��׸��
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
