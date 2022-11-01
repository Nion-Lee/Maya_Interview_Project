# Maya_Interview_Project
這兩天陸陸續續做了將近20小時  
因為時間關係，目前只有做了後端跟資料流的部分，前端相關的畫面、框架、套件的PDF下載目前是null

這個方案最主要展示了.NET6的Web API，並以粗淺的DDD模式去架構資料層級  
裏頭使用了Code First及Migration，還有DI、分層式的架構去分離Controller與Service的職責  
另外還帶到DTO的概念，雖然這部分還沒把它串進去就是了  

<使用方式>  
該方案git clone下來之後，先編譯一次下載尚未下載的"紐給"包  
接著以指令進入WebApi資料目錄，輸入: dotnet ef migrations add InitialCreate  
接著: dotnet ef database update  
若這兩部份指令沒錯誤，資料庫就完成了，這時就可以直接開始Run起該WebApi專案  

控制器裡面只有四支action，就最基本的新刪查找這樣  
然後因為專案run起時我有seed初始資料進去，所以可以直接進GetAll這支API看當前有哪幾筆資料這樣  

另外資料庫部分我有做基本的正規化，但到最下面那層就沒有@@，因為最下面那層有json物件.....
