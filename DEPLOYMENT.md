# CRM 系統部署指南

本指南說明如何部署 CRM 客戶管理系統到 Azure Static Web Apps 並配置 Azure Cosmos DB。

## 準備工作

### 1. Azure 資源需求
- Azure 訂閱帳戶
- Azure Cosmos DB 帳戶
- GitHub 帳戶

## 步驟一：設置 Azure Cosmos DB

1. **創建 Cosmos DB 帳戶**
   - 登入 Azure 入口網站
   - 創建新的 Azure Cosmos DB 帳戶
   - 選擇 Core (SQL) API
   - 選擇適當的區域

2. **創建資料庫和容器**
   ```
   資料庫名稱：CRMDatabase
   容器名稱：Customers
   分割區索引鍵：/partitionKey
   ```

3. **取得連線資訊**
   - 複製 URI（端點）
   - 複製主要金鑰（Primary Key）

## 步驟二：設置 GitHub 存放庫

1. **推送程式碼到 GitHub**
   ```bash
   git remote add origin https://github.com/your-username/your-repo-name.git
   git branch -M main
   git push -u origin main
   ```

## 步驟三：創建 Azure Static Web App

1. **在 Azure 入口網站創建 Static Web App**
   - 搜尋並選擇「Static Web Apps」
   - 點擊「創建」
   - 選擇訂閱和資源群組
   - 輸入應用程式名稱
   - 選擇免費方案

2. **配置部署詳細資料**
   - **Source**: GitHub
   - **Organization**: 您的 GitHub 帳戶
   - **Repository**: 您的存放庫
   - **Branch**: main
   - **Build Presets**: Custom
   - **App location**: `/`
   - **Output location**: `dist/wwwroot`

3. **完成創建**
   - Azure 會自動在您的 GitHub 存放庫創建 workflow 檔案
   - 第一次部署會自動開始

## 步驟四：配置環境變數

1. **在 Azure Static Web App 中設定應用程式設定**
   - 進入您的 Static Web App 資源
   - 點擊「組態」
   - 在「應用程式設定」中添加：
     ```
     CosmosDb__Endpoint: https://your-cosmosdb-account.documents.azure.com:443/
     CosmosDb__Key: your-primary-key-here
     CosmosDb__DatabaseName: CRMDatabase
     CosmosDb__ContainerName: Customers
     ```

## 步驟五：設置自定義網域（可選）

1. **在 Static Web App 中設定自定義網域**
   - 點擊「自定義網域」
   - 添加您的網域
   - 遵循 DNS 驗證步驟

## 步驟六：驗證部署

1. **檢查部署狀態**
   - 在 GitHub Actions 中查看工作流程執行狀態
   - 確認所有步驟都成功完成

2. **測試應用程式**
   - 造訪您的 Static Web App URL
   - 測試各項功能：
     - 客戶列表載入
     - 新增客戶
     - 編輯客戶資料
     - 投資記錄管理
     - 拜訪記錄管理

## 步驟七：生產環境優化

### 安全性設定
1. **限制 Cosmos DB 存取**
   - 在 Cosmos DB 的「防火牆和虛擬網路」中
   - 只允許 Azure 服務存取
   - 或設定特定 IP 範圍

2. **啟用身分驗證（建議）**
   - 在 Static Web App 的「身分驗證」中
   - 設定身分識別提供者（Azure AD、GitHub 等）

### 效能最佳化
1. **Cosmos DB 效能**
   - 監控 RU 消耗
   - 適當調整 RU 設定
   - 設定索引原則

2. **CDN 設定**
   - Static Web Apps 已內建 CDN
   - 可檢查快取設定

## 疑難排解

### 常見問題

1. **Cosmos DB 連線失敗**
   - 檢查端點和金鑰是否正確
   - 確認防火牆設定允許存取
   - 檢查應用程式設定格式

2. **部署失敗**
   - 檢查 GitHub Actions 錯誤訊息
   - 確認 .NET 版本相容性
   - 檢查建置路徑設定

3. **功能無法使用**
   - 檢查瀏覽器開發者工具的錯誤訊息
   - 確認 JavaScript 是否已啟用
   - 檢查網路連線

### 監控和維護

1. **Azure Monitor**
   - 設定監控和警示
   - 追蹤應用程式使用量

2. **定期備份**
   - 設定 Cosmos DB 自動備份
   - 定期匯出重要資料

3. **更新維護**
   - 定期更新套件版本
   - 監控安全性更新

## 支援

如需協助，請：
1. 檢查 Azure 文件
2. 查看 GitHub Issues
3. 聯絡技術支援團隊

---

**注意**: 此部署指南假設您已有基本的 Azure 和 GitHub 使用經驗。如果是初次使用，建議先熟悉相關平台的基本操作。