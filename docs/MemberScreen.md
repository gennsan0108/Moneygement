# 真ん中のTabのメンバー一覧を表示するScreen  

## memberListManager  
- Roomクラスの参加者を表示する  
- メンバーの「i」ボタンを押すと、部屋の合計の支払いをPaymentClassのcalculataから計算して各メンバーの最終的な収支を表示する

## memberTag
- メンバー表示するtag(Prefab)にアタッチされている  
- personインスタンスを持ち、Prefabで表示させることでやり取りをわかりやすくする

## HowMuchTag  
「i」ボタンを押したときにホップアップとして出てくる情報を管理する  
すべてのメソッドは引数にCreditを持ち、Prefabに以下の内容をテキストにセットする
- SetupForPayee
  払われる人(相手)の収支をセット
- SetupForpayer
  払う人(相手)の収支をセット
- SetupSummary
  払う人から払われる人への収支をセット
