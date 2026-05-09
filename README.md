# Moneygement

## 概要
グループ内の支払いを記録し、
最終的な収支計算と、
**最小回数で**精算を行う割り勘管理アプリです
[紹介動画はこちら](https://drive.google.com/file/d/1pJZbODuQ-ZIUnzs-UXkUmJEMyNv4Qxax/view?usp=sharing)
## 機能
詳しくはdocsに紹介


### Screen
- HomeScreen:
アプリ起動時に最初に現れる画面。 グループ選択、追加を管理する

- ManagementScreen:
金銭のやり取りを追加する画面。だれが(複数選択可)いくら払ったかを入力し、支払い名を決めて追加する

- MemberScreen:
メンバーのリストを表示する。今まで追加した金銭のやり取りにより各々の払う金額を算出する

- HistoryScreen:
支払いの履歴を確認できる。支払いごとの割り勘を算出する


## 開発環境
- Unity6 6000.3.9f1
- C#

## 今後の予定
- FireBaseを用いてDB実装
- 他人が参加可能なようにグループを実装
- Google Storeにて公開

## 工夫した点
- UIとデータ処理を分けて設計できた
- Screenの数を必要最小限にして情報量を絞ることでUXを改良した
- 可読性を高めるためにメソッドをできるだけ切り分けた

## 反省点
- UnityはゲームエンジンなのでUnityで作る必要性はなかった。それがネックとなり、platformが限られてしまった
