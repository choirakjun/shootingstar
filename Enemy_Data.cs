public class Enemy_Data{
	private int HP;
	public Enemy_Data(int _HP){
		HP = _HP;
	}
	public void decreaseHP(int damage){
		HP -=damage;
	}

	public int getHP ()
	{
		return HP;
	}
}