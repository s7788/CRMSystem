# CRM 客戶管理系統

基於 Blazor WebAssembly 開發的客戶關係管理系統，支援多人協作編輯，串接 Azure Cosmos DB 資料庫。

## 系統功能

### 1. 多人協作與編輯
- 支援 3-5 位成員同時上線編輯
- 團隊成員輸入或修改資料時能即時同步

### 2. 客戶基本資料管理
- 姓名、性別、出生日期
- 地址、電話/手機
- 子女資訊、職業
- 客戶來源（銀行、朋友、親戚等）
- 客戶歸屬（團隊成員分配）

### 3. 投資記錄追蹤
- 下單日期、幣別、基金名稱、金額
- 損益狀況追蹤
- 多種資產類型（基金、債券、股票、存款）
- 與拜訪記錄聯動更新

### 4. 拜訪記錄管理
- 拜訪日期與負責人
- 主要對話內容記錄
- 投資或保單調整處理
- 後續追蹤事項規劃
- 完整的客戶追蹤歷程

### 5. 備註與個人化資訊
- 客戶習慣與生活細節
- 通常在家時間、喜好記錄
- 便於團隊更貼近客戶需求

## 技術架構

- **前端框架**: Blazor WebAssembly (.NET 9)
- **資料庫**: Azure Cosmos DB
- **雲端平台**: Azure Static Web Apps
- **版本控制**: GitHub
- **CI/CD**: GitHub Actions

## 開發環境設置

### 先決條件
- .NET 9 SDK
- Visual Studio 2022 或 VS Code
- Azure 帳戶
- GitHub 帳戶

### 本地開發設置

1. **克隆專案**
   ```bash
   git clone https://github.com/your-username/CRMTest.git
   cd CRMTest
   ```

2. **還原套件**
   ```bash
   dotnet restore
   ```

3. **配置 Azure Cosmos DB**
   - 在 Azure 入口網站建立 Cosmos DB 帳戶
   - 建立資料庫: `CRMDatabase`
   - 建立容器: `Customers`，分割區索引鍵: `/partitionKey`
   - 更新 `wwwroot/appsettings.json` 中的連線資訊

4. **執行應用程式**
   ```bash
   dotnet run
   ```

### Azure 部署設置

1. **建立 Azure Static Web App**
   - 在 Azure 入口網站建立 Static Web App
   - 連接到 GitHub 存放庫
   - 設定建置詳細資料：
     - App location: `/`
     - Output location: `dist/wwwroot`

2. **設定環境變數**
   在 Azure Static Web App 的配置中設定：
   - `CosmosDb__Endpoint`: Cosmos DB 端點
   - `CosmosDb__Key`: Cosmos DB 主要金鑰

3. **GitHub Secrets 設定**
   在 GitHub 存放庫設定中添加：
   - `AZURE_STATIC_WEB_APPS_API_TOKEN`: 從 Azure 取得的部署權杖

## 資料模型

### Customer (客戶)
- 基本資料：姓名、性別、出生日期、地址、聯絡方式
- 背景資訊：職業、子女資訊、客戶來源、歸屬
- 關聯資料：投資記錄清單、拜訪記錄清單

### InvestmentRecord (投資記錄)
- 交易資訊：下單日期、幣別、基金名稱、金額
- 績效追蹤：損益狀況、狀態
- 資產分類：基金、債券、股票、存款等

### VisitRecord (拜訪記錄)
- 拜訪資訊：日期、負責人
- 內容記錄：對話內容、投資調整、後續追蹤

## 使用指南

1. **客戶管理**：從側邊欄進入「客戶管理」查看所有客戶
2. **新增客戶**：點擊「新增客戶」建立新的客戶檔案
3. **客戶詳情**：點擊客戶名稱查看完整資料
4. **投資記錄**：在客戶詳情頁面管理投資組合
5. **拜訪記錄**：記錄每次客戶互動與後續追蹤

## 安全性考量

- 使用 Azure AD 或其他身分驗證提供者（建議實作）
- Cosmos DB 連線字串應存放在安全的環境變數中
- 實作適當的角色型存取控制

## 授權

此專案採用 MIT 授權條款。

## 貢獻

歡迎提交 Issue 和 Pull Request 來改善系統功能。