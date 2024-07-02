using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {

            new VillaDto{Id=1, Name="SOUHAIL" ,Occupancy=15,Sqft=110 },
            new VillaDto{Id=2, Name="oussama" ,Occupancy=24,Sqft=45},
            new VillaDto{Id=3, Name="Ali" ,Occupancy=9,Sqft=30},
            new VillaDto{Id=4, Name="amin" ,Occupancy=8,Sqft=540},
            new VillaDto{Id=5, Name="anas",Occupancy=14,Sqft=10}

        };
    }
}
