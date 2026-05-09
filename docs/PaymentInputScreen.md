# 支払い入力画面について

## ManagementSceneManager
- AddPaymentButton  
支払いを追加するボタンにて呼び出される  
入力バリデーションをチェックして、実際にRoomインスタンスに追加する
追加されると入力をリセットする(ClearPaymentInput())


- AddPaymentMember  
Start()で呼び出され、メンバーの入力するアイテムを表示する

- RemoveMember  
roomインスタンスからメンバーを削除する

## PaymentRecordClass

支払い自体のインスタンス

- 支払い名
- 合計金額
- 参加者全員の支払い金額をもつDict型フィールド(getterあり)
  を保持
### メソッド
- SetMemberPayment  
  支払いをするメンバーが誰でいくらかを登録する
- AddMember  
  グループにメンバーを追加するときに呼び出され、Dictに追加される
- HasPaid  
  バリデーションチェックに利用され、Dictに1以上の数が登録されていればtrueを返す
- CombinePayment  
  roomインスタンスの合計支払いを計算するときに呼び出されて、引数にあるPaymentを合算する
- calculate  
    PaymentのDictの情報から払う人払われる人のマッチマッチングをしてCreditのList型を返す
  #### CreditClass
  支払う人、支払われる人、金額を持つ

