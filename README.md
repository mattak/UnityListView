# ListViewの作成

# 作業手順

## 1. プロジェクトの作成

Newを選択

![New](art/1-new.png)

名前を入力する

- 入力 "UnityListView"
- 2Dを選択

![Name](art/1-name.png)

## 2. Previewのサイズ設定

1. Gameタブを選択
2. "Free Aspect" をドロップダウン
3. "+" ボタンを選択

![PreviewSize](art/2-display.png)

縦画面で9:16の画面をつくる

- Label: ""
- Type: "Aspect Ratio"
- Width & Height: 9 16

![Aspect](art/2-aspect.png)

以後、シーンは9:16を選択して縦画面にする

![ListView](art/2-scene.png)

## 3. Common.unityの作成

Common.unity保存

- File > Save Scene (もしくは cmd + s)
- 名前: "Assets/Scenes/Common.unity"

![Save Scene](art/3-save.png)

UI Imageの作成
- GameObject > UI > Image

![Create Image](art/3-image.png)

これでCanvas, Image, EventSystemが生成される

![Created Image](art/3-created.png)

## 4. List.unity作成

Sceneを作成

- File > New Scene

![New Scene](art/4-new.png)

List.unity保存

- Path: "Assets/Scenes/List.unity"

![Save Scene](art/4-list.png)

## 5. MultiSceneEditting

Common.unityを開く

- ProjectTreeからCommon.unityを開く

![Open Common](art/5-common.png)

List.unityをHierarchyにDrag & Drop

- 複数のシーンが表示される

![Drag & Drop List](art/5-multi.png)

## 6. Canvasを移動

Canvasを移動
- Common.unity から List.unity

| Before | After |
|-----------------------------|----------------------------|
| ![Before](art/6-before.png) | ![After](art/6-after.png) |

## 7. Cameraの名前をリネーム

- Common.unity の"Main Camera" => "CommonCamera"
- List.unity の"Main Camera" => "ListCamera"

![Rename Camera](art/7-rename.png)

## 8. Canvasの設定

Canvasの設定

- Canvasを選択
- Screen Space - Cameraにする
- Render Camera > "ListCamera" にする

![Render Mode](art/8-mode.png)
![Render Mode](art/8-listcamera.png)

CanvasScalerの設定

- UI Scale Mode: "Scale With Screen Size"
- Reference Resolution: x "1080", y "1920"

![Canvas Scaler](art/8-scaler.png)

## 9. ListViewをつくる

Canvas > Imageのリネーム
- "Image" -> "ListView" にリネーム

![Name](art/9-name.png)

Canvas > ListView > Imageの作成
- ListViewを右クリック
- UI > Image で子Viewを作成
- リネーム: "Image" -> "ContentView"

![content view](art/9-contentview.png)
![rename content view](art/9-rename.png)

ListViewとContentViewを全画面にする

- RectTransformの図形を選択
- Altキーを押すと表示が変わる、その状態で右下の全体にひろげる状態をクリック

![before view](art/9-beforeall.png)
![after view](art/9-afterall.png)

同様にContentViewも位置の指定

- Pivot x: 0.5 y: 1
- Altおしながら、Top & Stretchを選択 

![content view all](art/9-content_transform.png)

ListViewにScroll Rectを追加
- Add Component: "Scroll Rect"
- ContentにContentViewを追加
- Horizontalのチェックを外す

![ScrollRect](art/9-scrollrect.png)
![ScrollRect Value](art/9-scrollrect_value.png)

ListViewにマスクを追加

- AddComponent: "Mask"

![Mask](art/9-mask.png)


ContentViewにVertical Layout Groupを追加
- Add Component: Vertical Layout Groupを追加
  - Child Force ExpandのHeightのチェックはずす

![Vertical](art/9-vertical.png)

ContentViewにContent Size Filterを追加
- Add Component: ContentSizeFilter 追加
- Vertical Fit: "Preferred Size"

![Vertical](art/9-content_size_filter.png)

## 10. ListItemを作ろう

ContentView > Button
- "Button" => "ItemView"にリネーム
- Layout Elementを追加
    - Min Heightを100に設定

![ListItemView](art/10-listitemview.png)
![layout element](art/10-layoutelement.png)
![minheight](art/10-minheight.png)

わかりやすく背景色を変更

![Color](art/10-button_color.png)

赤とかにしておく

