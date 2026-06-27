namespace インターフェイス分離の原則
{
    // public interface IDevice
    // {
    //     void Print();
    //     void Fax();
    //     void Scan();
    // }

    public interface IPrint
    {
        void Print();
    }
    public interface IFax
    {
        void Fax();
    }
    public interface IScan
    {
        void Scan();
    }
    public interface IPrintFax : IPrint, IFax// ← 推奨されない
    {

    }
}