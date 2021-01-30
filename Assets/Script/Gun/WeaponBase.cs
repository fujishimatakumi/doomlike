//武器の基礎的な情報を保持する基底クラス
//武器のクラスはこのクラスを継承して作成する
abstract class WeaponBase
{
    //武器の攻撃力
    protected int _weaponAtackValue;
    //武器識別用列挙型
    protected WEAPONE_ID _id;
    //使用制限(銃の場合は最大弾薬数の意)
    protected int _weaponUsedRimit;

    public int WeaponAtackValue => _weaponAtackValue;
    public WEAPONE_ID WeaponId => _id;
    public int WeaponUsedRimit => _weaponUsedRimit;


    //各武器の攻撃を処理する関数
    public abstract void WeaponAtack();
}

public enum WEAPONE_ID
{
    Gun,
    Sorde
}