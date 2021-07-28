namespace Diet.App.Api.Security.Hash.Architecture
{
    public interface IHashProcessor
    {
        byte[] Compute(string dataToCompute);

        string ComputeToBase64String(string dataToCompute);
    }
}
