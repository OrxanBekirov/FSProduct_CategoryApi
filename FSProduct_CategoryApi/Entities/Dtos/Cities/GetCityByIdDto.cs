namespace FSProduct_CategoryApi.Entities.Dtos.Cities
{
    public class GetCityByIdDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public string CountryName { get; set; }
    }
}
