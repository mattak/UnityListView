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

Canvasにスクリプトを追加
(クロスシーンのカメラを一意に参照するように変更)

- [CameraFinder.cs](https://gist.github.com/mattak/b49bb8066f285123f963703c9f33a060#file-camerafinder-cs) を Assets/ScriptsにDL
- Add Component: CameraFinder

![Finder](art/7-finder.png)

ついでに"ListCamera"のAudioListenerをDisableにしておく.
(複数のAudioListenerが存在するとログに注意がでる)

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
灰色(`#CACACA`) とかにしておく

![Color](art/10-gray.png)

Textの状態を変更
- RectTransform: stretch x stretch
    - Left: 40, Right: 40, Top: 0, Bottom: 0
- Text
    - Text: "ListItem"
    - FontSize: 56
    - Alignment: Left

![Text](art/10-text.png)

"Assets/Prefabs" フォルダを作成.
HierarchyのListItemViewを選択して、作成したフォルダにDrag&Dropする

![Prefab](art/10-prefab.png)

Prefabとして実体ができたので、HierarchyのListItemViewは削除

![Remove GameObject](art/10-remove.png)

## 11. ListItemViewを追加するボタンを作成

Canvasにボタンを追加

- Canvasを選択
- 右クリック UI > Button
- 名前: "AddButton"

![Component](art/11-component.png)
![Name](art/11-name.png)

ボタンの位置を下付きにする
- RectTransform: stretch bottom
    - Pivot x:0.5, y:0
    - Height: 200

![Transform](art/11-transform.png)

ボタンのテキストサイズを変更
- FontSize: 56
- Text: "追加"

![Text](art/11-text.png)

## 12. ListItemViewを追加するScriptをアタッチ

Assets/Scripts/AddButton.csを作成

![Script](art/12-script.png)

- [AddButton.cs](https://github.com/mattak/UnityListView/blob/master/Assets/Scripts/AddButton.cs)を書く、もしくはDL

![Add](art/12-add.png)

AddButtonにScriptを追加

- AddButtonを選択
- Add Component: "AddButton"
- Prefab: "ListItemView" (ProjectよりAssets/Prefabs/ListItemViewよりDrag&Drop)
- Add To: "ContentView" (HierarchyよりContentViewをDrag&Drop)

![Add](art/12-select.png)

実行して、アイテム追加できればOK

![Item](art/12-done.png)

お疲れ様でした。

