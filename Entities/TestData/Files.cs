using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    private string[] FileList = {
      "3fbe2aea-2257-44f2-b3b1-3d8bacade89c.jpg",
      "43de8b65-8b19-4b87-ae3c-df97e18bd461.jpg",
      "46194927-ccda-432f-bc95-4820318c08c7.jpg",
      "4cdd494c-e6e1-4af1-9e54-24a8e80ea2b4.jpg",
      "5c20ca95-bb00-4ef1-8b85-c4b11e66eb54.jpg",
      "6b33c074-65cf-4f2b-913a-1b2d4deb7050.jpg",
      "7e80a4c8-0a8a-4593-a16f-2e257294a1f9.jpg",
      "8d351bbb-f760-4b56-9d4e-e8d61619bf70.jpg",
      "b2894002-0b7c-4f05-896a-856283012c87.jpg",
      "cc412f08-2a7b-4225-b659-07fdb168302d.jpg",
      "cd139111-c82e-4bc8-9f7d-43a1059bfe73.jpg",
      "dc3f39bf-d1da-465d-9ea4-935902c2e3d2.jpg",
      "e0e32179-109c-4a8a-bf91-3d65ff83ca29.jpg",
      "fdfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "1dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "2dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "3dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "4dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "5dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
      "6dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
    };

    private File[] getFiles() {
      var files = new File[FileList.Length];

      for (int i = 0; i<FileList.Length; i++) {
        files[i] = new File() { Id = i+1, Name = FileList[i] };
      }

      return files;
    }

    public File[] Files
    {
      get => getFiles();
    }
  }
}
