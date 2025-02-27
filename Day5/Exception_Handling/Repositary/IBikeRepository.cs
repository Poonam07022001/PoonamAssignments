using Exception_Handling.Modal;

namespace Exception_Handling.Repositary
{
    internal interface IBikeRepository
    {
        bool AddBike(Bike bike);
        List<Bike>GetAllBikes();

        Bike GetBikeByName(string name);
    }
}
