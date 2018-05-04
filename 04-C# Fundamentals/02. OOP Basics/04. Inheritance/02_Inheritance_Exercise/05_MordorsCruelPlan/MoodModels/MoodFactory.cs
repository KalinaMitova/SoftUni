public class MoodFactory
{
    public static Mood GetType(int points)
    {
        Mood mood;

        if (points < -5)
        {
            mood = new Angry(points);
        }
        else if (points <= 0)
        {
            mood = new Sad(points);
        }
        else if (points <= 15)
        {
            mood = new Happy(points);
        }
        else
        {
            mood = new JavaScript(points);
        }

        return mood;
    }
}
