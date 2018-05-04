public class FoodFactory
{
    public static Food GetType(string foodName)
    {
        Food food;

        switch (foodName.ToLower())
        {
            case "cram":
                food = new Cram(foodName);
                break;
            case "lembas":
                food = new Lembas(foodName);
                break;
            case "apple":
                food = new Apple(foodName);
                break;
            case "melon":
                food = new Melon(foodName);
                break;
            case "honeycake":
                food = new HoneyCake(foodName);
                break;
            case "mushrooms":
                food = new Mushrooms(foodName);
                break;
            default:
                food = new Food(foodName);
                break;
        }

        return food;
    }
}