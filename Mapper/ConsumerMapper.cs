
using api.Dto.Consumer;
using api.Models;


namespace api.Mapper
{
    public static class ConsumerMapper
    {

        public static ConsumerDto ToConsumerDto(this Consumer consumerModel)
        {
            return new ConsumerDto
            {
                Id = consumerModel.Id,
                AccountName = consumerModel.AccountName,
                FirstName = consumerModel.FirstName,
                LastName = consumerModel.LastName,
                BirthDate = consumerModel.BirthDate,
                Mobile = consumerModel.Mobile,
                Addresses = consumerModel.Address.Select(el => el.ToAddressDto()).ToList()
            };
        }
        public static Consumer ToConsumerFromCreateDto(this CreateConsumerRequestDto consumerDto)
        {

            return new Consumer
            {
                AccountName = consumerDto.AccountName,
                FirstName = consumerDto.FirstName,
                LastName = consumerDto.LastName,
                BirthDate = consumerDto.BirthDate,
                Mobile = consumerDto.Mobile

            };
        }

    }
}