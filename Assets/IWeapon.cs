interface IWeapon
{
    string Name { get; }
    float Damage { get; set; }

    void LevelUp();
}