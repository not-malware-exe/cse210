public static class Levels
{
    private static Dictionary<int,string> _levels = new Dictionary<int, string>
    {
        {1638400,"Despite Everything... It's Still You.. A Loser"},
        {819200,"Wow, You Are Still a Loser"},
        {409600,"Still Going, You Will Never Not Be a Loser"},
        {204800,"There Is One Loser Here, And It Is Not Me"},
        {102400,"Gullible Loser"},
        {51200,"There Is Nothing Beyond This Point"},
        {25600,"If Being a Loser Was a Job You Would Have More Money Than The Rest of The World Combined, Unfortunately It Is Not a Job, Loser"},
        {12800,"Perhaps Your Cool, Or Your Just a Loser, I Bet on The Latter."},
        {6400,"You Are Not a Loser.. That Is If I Want To Lie To Myself"},
        {3200,"... Loser"},
        {1600,"Is Your Mom a Comedian, Because She Made a Joke, That Joke Was You"},
        {800,"Big L"},
        {400,"Still a Loser"},
        {200,"Loser"},
        {100,"Still a Big Loser"},
        {0,"Big Loser"},
        {-1,"There Are No Words To Describe How Big of a Loser You Are"}
    };

    public static string GetLevel(int points)
    {
        if (points >= 0)
        {
            foreach ((int pointThreshold, string levelName) in _levels)
            {
                if (points >= pointThreshold) return levelName;
            }
        }
        else return _levels[-1];
        return _levels[0];
    }
}