anko2MikuMikuMouth
===============
anko2MikuMikuMouthはやります！アンコちゃん用プラグインです。  
ニコ生のコメントをSocket接続された対象にコメント情報を逐次PUSH通知します。

機能
-------
起動するとポート*50082*でTCP Socketの待受を開始します。
ここにTCPで繋ぐことでニコ生のコメントを受け取ることができます。  コメント情報は新しいコメントが来る度に以下の要素が含まれたJSONがPUSHされます。

* Anonymity
* IsCaster
* UserId
* ProfName
* Name
* NickName
* Premium
* No
* Message
* Hiragana

Hiraganaにはひらがな変換されたコメント文が入っています。  
ただしひらがなに変換される文字は漢字とカタカナのみです。アルファベットや記号は変換されません。

導入方法
-------
anko2MikuMikuMouthはLGPLライセンスに基づいたNMecabを使用しています。  
http://sourceforge.jp/projects/nmecab 

LibNMecab.dllをplugins/以下に、
dicをあんこちゃん本体（exeがあるディレクトリ）と同じ場所に配置してください。


使い方
------
Unityで使うなら以下のスクリプトを使うと便利です。
https://github.com/TORISOUP/CommentViewer2Unity

著作権表記
------
anko2MikuMikuMouthは修正BSDライセンスに基づくkanaxs C# 1.0.0を使用しています。  
kanaxs C# 1.0.0 - Copyright (c) 2011, DOBON! <http://dobon.net>　All rights reserved.  
http://wiki.dobon.net/index.php?free%2FkanaxsCSharp%2Flicense