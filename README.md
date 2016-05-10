# ListViewの作成

# 作業手順

## 1. Common.unityの作成

2D新規
UI>Image作成
Common.unity保存

## 2. List.unity作成

Scene作成
- List.unity

Canvasを移動
- Common.unity から List.unity

Canvas
- Screen Space - Cameraにする
- Render Camera > Main Cameraにする

Common.unity
- Common Cameraにリネーム

Image
- ListViewにリネーム

ListView
- Image追加
- ContentViewにリネーム
- Scroll Rectを追加
    - ContentにContentViewを追加
    - Horizontalのチェックを外す

ContentView
- Vertical Layout Groupを追加
  - Child Force ExpandのHeightのチェックはずす

ContentView > Button
- ItemViewにリネーム
- Layout Elementを追加
    - Min Heightを100に設定

ItemView > Text
- 


