專案設定:
--------------------------------
1. 使用版本 建議不低於 Unity 2018。
2. Unity 專案設定API為 .Net4。
![image](https://github.com/gsp40213/PuchCard_Unity2019/blob/main/Assets/Image/ProjectSetting/ProjectSetting.png)

3. 發佈後執行結果與Unity 環境下操作結果不同，請匯入以下Dll 檔案
        
        I18N.CJK.dll    
        I18N.CJK.dll    
        I18N.Other.dll    
        I18N.Rare.dll   
        I18N.West.dll    
        I18N.dll   
    
3.1 檔案路徑為 Unity 安裝路徑:
    
    例如: C:\Program Files\Unity 2019.4.34f1\Editor\Data\MonoBleedingEdge\lib\mono\unityjit

3.2 專案匯入出現 System.Drawing.dll 錯誤，表示與當下Unity版本不符合，請至3.1 步驟。

專案內容說明:
--------------------------------
1. 自動建立檔案至D槽底下，建立班表資料夾
2. 每個檔案名稱: 使用者設定年份與月份 (xlsx檔案)
3. 預設班表: 沒有任何公式計算，班表樣式。
4. 公式班表:

        4.1 班別輸入: D 白班、E 晚班 N 夜班

        4.2 假別輸入: 休、特、病、公、喪、婚、公病、事、災

        4.3 加班顯示: D4/4D: 白班加4小時，也可以輸入小寫

        4.4 當天營業時段只提供每班8小時與12小時檢查

--------------------------------
勞動部-勞動基準法相關假別 參考網站:
https://www.mol.gov.tw/1607/28162/28166/28218/28226/30382/
--------------------------------

結果畫面:
--------------------------------
![image](https://github.com/gsp40213/PuchCard_Unity2019/blob/main/Assets/Image/ResultGraph/ResultGraph%20.png)

影片測試 (Unity 2019 LTS 版本):
--------------------------------
https://www.youtube.com/watch?v=ZQUQe4v4xjs


