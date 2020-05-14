namespace Hero
{
    public interface ITarget
    {
        bool IsDead();
        int GiveExperience();
        void TakeAttack(int damage);

    }
}
