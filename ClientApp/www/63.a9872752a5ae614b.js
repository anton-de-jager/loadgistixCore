"use strict";(self.webpackChunkloadgistix=self.webpackChunkloadgistix||[]).push([[63],{1708:(P,I,s)=>{s.d(I,{I:()=>_});var S=s(7445),e=s(5e3),i=s(8279),v=s(7261),Z=s(6407),u=s(8951),E=s(4521),U=s(9808),b=s(9224);function t(l,x){if(1&l&&e._UZ(0,"img",7),2&l){const d=e.oxw().$implicit;e.Q6J("src","/Images/Adverts/"+d.id+d.avatar,e.LSH)}}function y(l,x){if(1&l&&(e.TgZ(0,"mat-card",3),e.TgZ(1,"mat-card-title-group"),e.TgZ(2,"mat-card-title",4),e._uU(3),e.qZA(),e.TgZ(4,"mat-card-subtitle"),e._uU(5),e.qZA(),e.YNc(6,t,1,1,"img",5),e.qZA(),e.TgZ(7,"mat-card-content"),e._uU(8),e._UZ(9,"br"),e._UZ(10,"br"),e.TgZ(11,"a",6),e._uU(12),e.qZA(),e.qZA(),e.qZA()),2&l){const d=x.$implicit;e.xp6(3),e.Oqu(d.title),e.xp6(2),e.Oqu(d.subTitle),e.xp6(1),e.Q6J("ngIf",d.avatar),e.xp6(2),e.hij(" ",d.content,""),e.xp6(3),e.Q6J("href",d.link,e.LSH),e.xp6(1),e.Oqu(d.link)}}function k(l,x){if(1&l&&(e.ynx(0),e.YNc(1,y,13,6,"mat-card",2),e.BQk()),2&l){const d=e.oxw();e.xp6(1),e.Q6J("ngForOf",d.advertItems)}}function g(l,x){1&l&&(e.TgZ(0,"mat-card",3),e.TgZ(1,"mat-card-title-group"),e.TgZ(2,"mat-card-title",4),e._uU(3,"Loadgistix"),e.qZA(),e.TgZ(4,"mat-card-subtitle"),e._uU(5,"Get more"),e.qZA(),e._UZ(6,"img",8),e.qZA(),e.TgZ(7,"mat-card-content"),e._uU(8," Contact us today - we will show you how to get the best out of Loadgistix! "),e.qZA(),e.qZA())}let _=(()=>{class l{constructor(d,A,h,w,L){this.apiService=d,this._snackBar=A,this.variableService=h,this.authService=w,this._router=L,this.loading=!0,this.advertItems=[]}ngOnInit(){this.getAdverts().then(A=>{this.advertItems=A});const d=(0,S.F)(6e5);this.subscription=d.subscribe(A=>{this.authService.check().subscribe(h=>{h&&this.getAdverts().then(w=>{this.advertItems=w})})})}getAdverts(){return new Promise(A=>{try{this.apiService.post("adverts","available",null).subscribe({next:h=>{1==h.result?A(h.data):"Expired"==h.message?this._router.navigate(["/sign-out"]):this._snackBar.open("Error: "+h.message,null,{duration:2e3})},error:h=>{console.log(h),this._snackBar.open("Error: "+h,null,{duration:2e3})},complete:()=>{}})}catch(h){A([])}})}}return l.\u0275fac=function(d){return new(d||l)(e.Y36(i.s),e.Y36(v.ux),e.Y36(Z.S),e.Y36(u.e),e.Y36(E.F0))},l.\u0275cmp=e.Xpm({type:l,selectors:[["advert"]],decls:2,vars:2,consts:[[4,"ngIf"],["class","flex flex-col flex-auto p-6 bg-card shadow rounded-2xl overflow-hidden","style","margin-bottom: 12px;",4,"ngIf"],["class","flex flex-col flex-auto p-6 bg-card shadow rounded-2xl overflow-hidden","style","margin-bottom: 12px;",4,"ngFor","ngForOf"],[1,"flex","flex-col","flex-auto","p-6","bg-card","shadow","rounded-2xl","overflow-hidden",2,"margin-bottom","12px"],[2,"font-size","18px"],["mat-card-sm-image","",3,"src",4,"ngIf"],["target","_blank",3,"href"],["mat-card-sm-image","",3,"src"],["mat-card-sm-image","","src","assets/images/no-image.jpg"]],template:function(d,A){1&d&&(e.YNc(0,k,2,1,"ng-container",0),e.YNc(1,g,9,0,"mat-card",1)),2&d&&(e.Q6J("ngIf",A.advertItems.length>0),e.xp6(1),e.Q6J("ngIf",0===A.advertItems.length))},directives:[U.O5,U.sg,b.a8,b.C1,b.n5,b.$j,b.dn,b.vP],styles:[".mat-card-sm-image[_ngcontent-%COMP%]{max-width:120px;max-height:120px;width:auto;height:auto}"]}),l})()},7738:(P,I,s)=>{s.d(I,{_:()=>k});var S=s(7295),e=s(7579),i=s(5e3),v=s(8966),Z=s(9808),u=s(7423);function E(g,_){if(1&g){const l=i.EpF();i.TgZ(0,"webcam",11),i.NdJ("imageCapture",function(d){return i.CHM(l),i.oxw(2).handleImage(d)}),i.qZA()}if(2&g){const l=i.oxw(2);i.Q6J("height",500)("width",1e3)("trigger",l.triggerObservable)("switchCamera",l.nextWebcamObservable)}}function U(g,_){if(1&g&&(i.TgZ(0,"ul"),i.TgZ(1,"li"),i._uU(2),i.ALo(3,"json"),i.qZA(),i.qZA()),2&g){const l=_.$implicit;i.xp6(2),i.Oqu(i.lcZ(3,1,l))}}function b(g,_){if(1&g&&(i.TgZ(0,"div"),i.TgZ(1,"h4"),i._uU(2,"Error Messages:"),i.qZA(),i.YNc(3,U,4,3,"ul",12),i.qZA()),2&g){const l=i.oxw(2);i.xp6(3),i.Q6J("ngForOf",l.errors)}}function t(g,_){if(1&g&&(i.TgZ(0,"div"),i.TgZ(1,"div",8),i.YNc(2,E,1,4,"webcam",9),i.qZA(),i.YNc(3,b,4,1,"div",10),i.qZA()),2&g){const l=i.oxw();i.xp6(2),i.Q6J("ngIf",l.showWebcam),i.xp6(1),i.Q6J("ngIf",l.errors.length>0)}}function y(g,_){1&g&&i._uU(0," Camera device not available ")}let k=(()=>{class g{constructor(l){this.dialogRef=l,this.showWebcam=!0,this.isCameraExist=!0,this.errors=[],this.trigger=new e.x,this.nextWebcam=new e.x}ngOnInit(){S.BF.getAvailableVideoInputs().then(l=>{this.isCameraExist=l&&l.length>0})}takeSnapshot(){this.trigger.next()}onOffWebCame(){this.showWebcam=!this.showWebcam}handleInitError(l){this.errors.push(l)}changeWebCame(l){this.nextWebcam.next(l)}handleImage(l){this.dialogRef.close(l)}get triggerObservable(){return this.trigger.asObservable()}get nextWebcamObservable(){return this.nextWebcam.asObservable()}cancel(){this.dialogRef.close(null)}}return g.\u0275fac=function(l){return new(l||g)(i.Y36(v.so))},g.\u0275cmp=i.Xpm({type:g,selectors:[["app-camera"]],decls:12,vars:2,consts:[["mat-dialog-title","",1,"accent","dialog-title","bg-primary","text-on-primary","text-secondary",2,"margin-bottom","0px !important"],["mat-dialog-content","",2,"padding","0!important"],[4,"ngIf","ngIfElse"],["noCameraExist",""],["mat-dialog-actions","",1,"dialog-footer",2,"margin-top","0px !important"],[2,"flex","1 1 auto"],["mat-raised-button","","color","warn",3,"click"],["mat-raised-button","","color","primary",3,"click"],[2,"text-align","center"],[3,"height","width","trigger","switchCamera","imageCapture",4,"ngIf"],[4,"ngIf"],[3,"height","width","trigger","switchCamera","imageCapture"],[4,"ngFor","ngForOf"]],template:function(l,x){if(1&l&&(i.TgZ(0,"h1",0),i._uU(1,"Take Photo"),i.qZA(),i.TgZ(2,"div",1),i.YNc(3,t,4,2,"div",2),i.YNc(4,y,1,0,"ng-template",null,3,i.W1O),i.qZA(),i.TgZ(6,"div",4),i._UZ(7,"span",5),i.TgZ(8,"button",6),i.NdJ("click",function(){return x.cancel()}),i._uU(9,"Cancel"),i.qZA(),i.TgZ(10,"button",7),i.NdJ("click",function(){return x.takeSnapshot()}),i._uU(11,"Take Photo"),i.qZA(),i.qZA()),2&l){const d=i.MAs(5);i.xp6(3),i.Q6J("ngIf",x.isCameraExist)("ngIfElse",d)}},directives:[v.uh,v.xY,Z.O5,v.H8,u.lW,S.i3,Z.sg],pipes:[Z.Ts],styles:[".button[_ngcontent-%COMP%]{color:#fff;background-color:#00f;padding:4px;text-align:center;text-decoration:none;display:inline-block;font-size:16px;margin:4px 2px;transition-duration:.4s;cursor:pointer;border-radius:2px}ul.links[_ngcontent-%COMP%]{padding-bottom:10px}"]}),g})()},3063:(P,I,s)=>{s.r(I),s.d(I,{AdvertsModule:()=>vt});var S=s(4521),e=s(3075),i=s(8966),v=s(6087),Z=s(4847),u=s(4999),E=s(3098),U=s(7579),b=s(7738),t=s(5e3),y=s(7261),k=s(6362),g=s(8279),_=s(7093),l=s(7322),x=s(4107),d=s(9808),A=s(7531),h=s(7423),w=s(508);function L(n,c){if(1&n&&(t.TgZ(0,"mat-option",26),t._uU(1),t.qZA()),2&n){const a=c.$implicit;t.Q6J("value",a.id),t.xp6(1),t.Oqu(a.description)}}function Y(n,c){1&n&&(t.TgZ(0,"mat-error"),t._uU(1,"Title is required"),t.qZA())}function N(n,c){1&n&&(t.TgZ(0,"mat-error"),t._uU(1,"Sub-Title is required"),t.qZA())}function F(n,c){1&n&&(t.TgZ(0,"mat-error"),t._uU(1,"Content is required"),t.qZA())}function J(n,c){1&n&&(t.TgZ(0,"mat-error"),t._uU(1,"Link is required"),t.qZA())}function B(n,c){if(1&n){const a=t.EpF();t.TgZ(0,"img",27),t.NdJ("click",function(){return t.CHM(a),t.oxw(),t.MAs(39).click()}),t.qZA()}if(2&n){const a=t.oxw();t.Q6J("src",a.previewImage,t.LSH)}}function Q(n,c){if(1&n){const a=t.EpF();t.TgZ(0,"img",27),t.NdJ("click",function(){return t.CHM(a),t.oxw(),t.MAs(39).click()}),t.qZA()}if(2&n){const a=t.oxw();t.Q6J("src","/Images/Adverts/"+a.form.value.id+a.form.value.avatar,t.LSH)}}function W(n,c){if(1&n){const a=t.EpF();t.TgZ(0,"img",28),t.NdJ("click",function(){return t.CHM(a),t.oxw(),t.MAs(39).click()}),t.qZA()}}let j=(()=>{class n{constructor(a,r,o,m,f,D){this.dialog=a,this.dialogRef=r,this.data=o,this._snackBar=m,this.fuseSplashScreenService=f,this.apiService=D,this.loading=!0,this.previewImage=null,this.hasError=(T,q)=>this.form.controls[T].hasError(q),this.formErrors=o.formErrors,this.formData=o,this._unsubscribeAll=new U.x}ngOnInit(){this.form=this.data.form,this.formValid=!1,this.loading=!1}handleFileInput(a){this.fileToUpload=a.item(0),this.form.controls.fileToUpload.setValue(this.fileToUpload);var r=(this.fileToUpload.size/1048576).toFixed(2);if(Number(r)>Number(.25))return this._snackBar.open("Error: Maximum FileSize is 200kB",null,{duration:2e3}),!1;{let o=new FileReader;o.onload=m=>{this.previewImage=m.target.result},o.readAsDataURL(this.fileToUpload)}}initCamera(){const a=new i.vA;a.autoFocus=!0,a.disableClose=!0,a.hasBackdrop=!0,a.ariaLabel="fffff",a.width="800px",this.dialog.open(b._,a).afterClosed().subscribe(o=>{o&&(this.form.controls.avatar.setValue(o._imageAsDataUrl),this.previewImage=o._imageAsDataUrl,this.form.controls.avatarChanged.setValue(!0))})}onNoClick(){this.dialogRef.close(!1)}onYesClick(){setTimeout(()=>{this.dialogRef.close(this.form.value)},100)}}return n.\u0275fac=function(a){return new(a||n)(t.Y36(i.uw),t.Y36(i.so),t.Y36(i.WI),t.Y36(y.ux),t.Y36(k.j),t.Y36(g.s))},n.\u0275cmp=t.Xpm({type:n,selectors:[["dialog-advert"]],decls:54,vars:11,consts:[["mat-dialog-title","",1,"accent","dialog-title","bg-primary","text-on-primary","text-secondary"],["mat-dialog-content","","fxLayout","column"],["fxLayout","column","fxLayoutAlign","start","fxFlex","1 0 auto","name","form","novalidate","",1,"mat-white-bg","w-100-p",2,"padding","0px!important",3,"formGroup"],["fxLayout","row wrap",1,"w-100-p"],["fxFlex","100","fxFlex.gt-xs","50",1,"p-4",2,"padding","0px!important"],["appearance","outline",1,"w-100-p"],["placeholder","Advert Package","formControlName","advertPackageId"],[3,"value",4,"ngFor","ngForOf"],["matInput","","placeholder","Title","maxlength","20","formControlName","title","id","title"],[4,"ngIf"],["matInput","","placeholder","Sub-Title","maxlength","50","formControlName","subTitle","id","subTitle"],["matInput","","placeholder","Content","maxlength","200","formControlName","content","id","content"],["matInput","","placeholder","Link","formControlName","link","id","link"],["fxFlex","100","fxFlex.gt-xs","50","fxLayout","row","fxLayoutAlign","center center",1,"p-4"],["id","fileInput","type","file","accept",".jpg,.png,.jpeg",2,"display","none",3,"change"],["Image",""],["fxFlex","","fxLayout","column"],["fxFlex","","fxLayout","row"],["mat-flat-button","","fxFlex","100","color","primary",2,"margin-left","2px","margin-right","2px",3,"click"],["fxFlex","","fxLayout","row","fxLayoutAlign","center center",2,"margin-top","4px"],["style","max-width: 120px;max-height: 120px;width: auto;height: auto;","class","image",3,"src","click",4,"ngIf"],["style","max-width: 120px;max-height: 120px;width: auto;height: auto;","src","assets/images/no-image.jpg","class","image",3,"click",4,"ngIf"],["mat-dialog-actions","",1,"dialog-footer"],[2,"flex","1 1 auto"],["mat-flat-button","","color","warn",3,"click"],["mat-flat-button","","color","primary",3,"disabled","click"],[3,"value"],[1,"image",2,"max-width","120px","max-height","120px","width","auto","height","auto",3,"src","click"],["src","assets/images/no-image.jpg",1,"image",2,"max-width","120px","max-height","120px","width","auto","height","auto",3,"click"]],template:function(a,r){if(1&a){const o=t.EpF();t.TgZ(0,"h1",0),t._uU(1),t.qZA(),t.TgZ(2,"div",1),t.TgZ(3,"form",2),t.TgZ(4,"div",3),t.TgZ(5,"div",4),t.TgZ(6,"mat-form-field",5),t.TgZ(7,"mat-label"),t._uU(8,"Advert Package"),t.qZA(),t.TgZ(9,"mat-select",6),t.YNc(10,L,2,2,"mat-option",7),t.qZA(),t.TgZ(11,"mat-error"),t._uU(12,"Advert Package is required"),t.qZA(),t.qZA(),t.qZA(),t.TgZ(13,"div",4),t.TgZ(14,"mat-form-field",5),t.TgZ(15,"mat-label"),t._uU(16,"Title"),t.qZA(),t._UZ(17,"input",8),t.YNc(18,Y,2,0,"mat-error",9),t.qZA(),t.qZA(),t.TgZ(19,"div",4),t.TgZ(20,"mat-form-field",5),t.TgZ(21,"mat-label"),t._uU(22,"Sub-Title"),t.qZA(),t._UZ(23,"input",10),t.YNc(24,N,2,0,"mat-error",9),t.qZA(),t.qZA(),t.TgZ(25,"div",4),t.TgZ(26,"mat-form-field",5),t.TgZ(27,"mat-label"),t._uU(28,"Content"),t.qZA(),t._UZ(29,"input",11),t.YNc(30,F,2,0,"mat-error",9),t.qZA(),t.qZA(),t.TgZ(31,"div",4),t.TgZ(32,"mat-form-field",5),t.TgZ(33,"mat-label"),t._uU(34,"Link"),t.qZA(),t._UZ(35,"input",12),t.YNc(36,J,2,0,"mat-error",9),t.qZA(),t.qZA(),t.TgZ(37,"div",13),t.TgZ(38,"input",14,15),t.NdJ("change",function(f){return r.handleFileInput(f.target.files)}),t.qZA(),t.TgZ(40,"div",16),t.TgZ(41,"div",17),t.TgZ(42,"button",18),t.NdJ("click",function(){return t.CHM(o),t.MAs(39).click()}),t._uU(43,"Upload Image"),t.qZA(),t.qZA(),t.TgZ(44,"div",19),t.YNc(45,B,1,1,"img",20),t.YNc(46,Q,1,1,"img",20),t.YNc(47,W,1,0,"img",21),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.TgZ(48,"div",22),t._UZ(49,"span",23),t.TgZ(50,"button",24),t.NdJ("click",function(){return r.onNoClick()}),t._uU(51,"Cancel"),t.qZA(),t.TgZ(52,"button",25),t.NdJ("click",function(){return r.onYesClick()}),t._uU(53,"Submit"),t.qZA(),t.qZA()}2&a&&(t.xp6(1),t.hij("",r.formData.title," Advert\n"),t.xp6(2),t.Q6J("formGroup",r.form),t.xp6(7),t.Q6J("ngForOf",r.formData.advertPackageList),t.xp6(8),t.Q6J("ngIf",r.hasError("title","required")),t.xp6(6),t.Q6J("ngIf",r.hasError("subTitle","required")),t.xp6(6),t.Q6J("ngIf",r.hasError("content","required")),t.xp6(6),t.Q6J("ngIf",r.hasError("link","required")),t.xp6(9),t.Q6J("ngIf",r.previewImage),t.xp6(1),t.Q6J("ngIf",!r.previewImage&&r.form.value.avatar),t.xp6(1),t.Q6J("ngIf",!r.previewImage&&!r.form.value.avatar),t.xp6(5),t.Q6J("disabled",!r.form.valid))},directives:[i.uh,i.xY,_.xw,e._Y,e.JL,_.Wh,_.yH,e.sg,l.KE,l.hX,x.gD,e.JJ,e.u,d.sg,l.TO,A.Nt,e.Fj,e.nD,d.O5,h.lW,i.H8,w.ey],encapsulation:2}),n})();var H=s(520),R=s(6407),z=s(1683),K=s(9224),G=s(1708),$=s(7238),X=s(5245);function V(n,c){if(1&n){const a=t.EpF();t.TgZ(0,"th",23),t.TgZ(1,"button",24),t.NdJ("click",function(){return t.CHM(a),t.oxw().initUpsert(null)}),t.TgZ(2,"mat-icon",25),t._uU(3,"add"),t.qZA(),t.qZA(),t.qZA()}if(2&n){const a=t.oxw();t.xp6(1),t.Q6J("disabled",a.loading)}}function tt(n,c){if(1&n){const a=t.EpF();t.TgZ(0,"td",26),t.TgZ(1,"button",27),t.NdJ("click",function(){const m=t.CHM(a).$implicit;return t.oxw().initUpsert(m)}),t.TgZ(2,"mat-icon",25),t._uU(3,"edit"),t.qZA(),t.qZA(),t.TgZ(4,"button",28),t.NdJ("click",function(){const m=t.CHM(a).$implicit;return t.oxw().initDelete(m.id)}),t.TgZ(5,"mat-icon",25),t._uU(6,"delete"),t.qZA(),t.qZA(),t.qZA()}if(2&n){const a=t.oxw();t.xp6(1),t.Q6J("disabled",a.loading),t.xp6(3),t.Q6J("disabled",a.loading)}}function et(n,c){1&n&&(t.TgZ(0,"th",29),t.TgZ(1,"p",30),t._uU(2,"Title"),t.qZA(),t.qZA())}function at(n,c){if(1&n&&(t.TgZ(0,"td",31),t._uU(1),t.qZA()),2&n){const a=c.$implicit;t.xp6(1),t.hij(" ",a.title," ")}}function it(n,c){1&n&&(t.TgZ(0,"th",29),t.TgZ(1,"p",32),t._uU(2,"Advert Package "),t.qZA(),t.qZA())}function nt(n,c){if(1&n&&(t.TgZ(0,"td",31),t._uU(1),t.qZA()),2&n){const a=c.$implicit;t.xp6(1),t.hij(" ",a.advertPackage?a.advertPackage.description:""," ")}}function rt(n,c){1&n&&(t.TgZ(0,"th",29),t.TgZ(1,"p",33),t._uU(2,"Image"),t.qZA(),t.qZA())}function ot(n,c){if(1&n&&t._UZ(0,"img",36),2&n){const a=t.oxw().$implicit;t.Q6J("src","/Images/Adverts/"+a.id+a.avatar,t.LSH)}}function st(n,c){1&n&&t._UZ(0,"img",37)}function lt(n,c){if(1&n&&(t.TgZ(0,"td",31),t.YNc(1,ot,1,1,"img",34),t.YNc(2,st,1,0,"img",35),t.qZA()),2&n){const a=c.$implicit;t.xp6(1),t.Q6J("ngIf",a.avatar),t.xp6(1),t.Q6J("ngIf",!a.avatar)}}function ct(n,c){1&n&&(t.TgZ(0,"th",29),t.TgZ(1,"p",38),t._uU(2,"Status"),t.qZA(),t.qZA())}function dt(n,c){if(1&n&&(t.TgZ(0,"td",31),t._uU(1),t.qZA()),2&n){const a=c.$implicit;t.xp6(1),t.hij(" ",a.status.description," ")}}function mt(n,c){1&n&&t._UZ(0,"tr",39)}function gt(n,c){1&n&&t._UZ(0,"tr",40)}const ut=function(){return[5,10,25,100]};let pt=(()=>{class n{constructor(a,r,o,m,f,D,T,q){this.dialog=a,this._formBuilder=r,this.apiService=o,this._snackBar=m,this.variableService=f,this._router=D,this.fuseSplashScreenService=T,this.fuseConfirmationService=q,this.loading=!0,this.advertList=[],this.advertPackageList=[],this.theFile=null,this.messages=[],this.fuseSplashScreenService.show(),this.loading=!0,this.displayedColumns=["cud","title","avatar","statusDescription"]}ngOnInit(){this.getAdvertPackages().then(a=>{this.advertPackageList=a,this.getAdverts().then(r=>{this.variableService.setPageSelected("Adverts"),this.advertList=r,this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1})})}getAdverts(){return new Promise(r=>{try{this.apiService.get("adverts").subscribe({next:o=>{1==o.result?r(o.data):"Expired"==o.message?this._router.navigate(["/sign-out"]):(this._snackBar.open("Error: "+o.message,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1)},error:o=>{console.log(o),this._snackBar.open("Error: "+o,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1},complete:()=>{}})}catch(o){r([])}})}getAdvertPackages(){return new Promise(r=>{try{this.apiService.post("advertPackages","all",null).subscribe({next:o=>{1==o.result?r(o.data):"Expired"==o.message?this._router.navigate(["/sign-out"]):(this._snackBar.open("Error: "+o.message,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1)},error:o=>{console.log(o),this._snackBar.open("Error: "+o,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1},complete:()=>{}})}catch(o){r([])}})}applyFilter(a){this.dataSource.filter=a.target.value.trim().toLowerCase(),this.dataSource.paginator&&this.dataSource.paginator.firstPage()}initUpsert(a){var r=new Date,o=r.getFullYear(),m=r.getMonth(),f=r.getDate(),D=new Date(o+1,m,f);this.form=this._formBuilder.group({id:[null==a?E.i.create().toString():a.id],userId:[null==a?localStorage.getItem("userId"):a.userId],dateExpiry:[null==a?D:a.dateExpiry],advertPackageId:[null==a?null:a.advertPackageId,e.kI.required],advertPackageDescription:[null==a?null:a.advertPackageDescription],title:[null==a?null:a.title,[e.kI.required,e.kI.maxLength(20)]],subTitle:[null==a?null:a.subTitle,[e.kI.required,e.kI.maxLength(50)]],link:[null==a?null:a.link,[e.kI.required,e.kI.maxLength(200)]],content:[null==a?null:a.content,[e.kI.required,e.kI.maxLength(200)]],avatar:[null==a?null:a.avatar],avatarChanged:[!1],fileToUpload:[null],statusId:[null==a?E.i.parse("490039A9-3DD3-4265-B998-FB735E2A233C").toString():a.statusId],statusDescription:[null==a?null:a.statusDescription]});const T=new i.vA;T.data={item:a,form:this.form,advertPackageList:this.advertPackageList,title:null==a?"Insert":"Update"},T.autoFocus=!0,T.disableClose=!0,T.hasBackdrop=!0,T.ariaLabel="fffff",T.width="800px",this.dialog.open(j,T).afterClosed().subscribe(C=>{!1!==C&&(this.fuseSplashScreenService.show(),this.loading=!0,null==a?this.apiService.post("adverts",null,C).subscribe({next:p=>{"00000000-0000-0000-0000-000000000000"!=p.id&&C.fileToUpload?this.uploadFile(C.fileToUpload,p.id+"."+C.fileToUpload.name.split(".").pop()).then(O=>{p.data.avatar="."+C.fileToUpload.name.split(".").pop(),this.advertList.push(p.data),this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1}):(this.advertList.push(p.data),this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1)},error:p=>{console.log(p),this._snackBar.open("Error: "+p,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1},complete:()=>{}}):this.apiService.put("adverts",C).subscribe({next:p=>{if(1==p.result)if("00000000-0000-0000-0000-000000000000"!=p.id&&C.fileToUpload)this.uploadFile(C.fileToUpload,p.id+"."+C.fileToUpload.name.split(".").pop()).then(O=>{p.data.avatar="."+C.fileToUpload.name.split(".").pop();let M=this.advertList.findIndex(_t=>_t.id===a.id);this.advertList[M]=p.data,this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1});else{let O=this.advertList.findIndex(M=>M.id===a.id);this.advertList[O]=p.data,this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1}else"Expired"==p.message?this._router.navigate(["/sign-out"]):(this._snackBar.open("Error: "+p.message,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1)},error:p=>{console.log(p),this._snackBar.open("Error: "+p,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1},complete:()=>{}}))})}initDelete(a){this.deleteForm=this._formBuilder.group({title:"Delete Advert",message:"Are you sure you want to remove this Advert?",icon:this._formBuilder.group({show:!0,name:"heroicons_outline:exclamation",color:"warn"}),actions:this._formBuilder.group({confirm:this._formBuilder.group({show:!0,label:"Remove",color:"warn"}),cancel:this._formBuilder.group({show:!0,label:"Cancel"})}),dismissible:!0}),this.fuseConfirmationService.open(this.deleteForm.value).afterClosed().subscribe(o=>{"confirmed"===o&&(this.fuseSplashScreenService.show(),this.loading=!0,this.apiService.delete("adverts",a).subscribe({next:m=>{1==m.result?(this.advertList.splice(this.advertList.findIndex(f=>f.id===m.id),1),this.dataSource=new u.by(this.advertList),this.fuseSplashScreenService.hide(),this.loading=!1):"Expired"==m.message?this._router.navigate(["/sign-out"]):(this._snackBar.open("Error: "+m.message,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1)},error:m=>{console.log(m),this._snackBar.open("Error: "+m,null,{duration:2e3}),this.fuseSplashScreenService.hide(),this.loading=!1},complete:()=>{}}))})}uploadFile(a,r){return new Promise(m=>{try{const f=new FormData;f.append("file",a),this.apiService.upload("adverts",f,r).subscribe(D=>{D.type===H.dt.Response&&m(!0)})}catch(f){m(!1)}})}getAddressSubstring(a,r){let o=a.split(r);return o.length>1?o[0]+","+o[1]:a}}return n.\u0275fac=function(a){return new(a||n)(t.Y36(i.uw),t.Y36(e.qu),t.Y36(g.s),t.Y36(y.ux),t.Y36(R.S),t.Y36(S.F0),t.Y36(k.j),t.Y36(z.R))},n.\u0275cmp=t.Xpm({type:n,selectors:[["adverts"]],viewQuery:function(a,r){if(1&a&&(t.Gf(v.NW,5),t.Gf(Z.YE,5)),2&a){let o;t.iGM(o=t.CRH())&&(r.paginatorAdvert=o.first),t.iGM(o=t.CRH())&&(r.sortAdvert=o.first)}},decls:30,vars:8,consts:[[1,"flex","flex-col","flex-auto","min-w-0"],["fusePerfectScrollbar","",1,"page-layout","blank","p-4"],[1,"grid","grid-cols-1","sm:grid-cols-6","gap-6","w-full","min-w-0"],[1,"sm:col-span-4","lg:col-span-4","flex","flex-col","flex-auto","p-6","overflow-hidden",2,"padding","0!important"],[1,"mt-0",2,"width","100%"],["matInput","","placeholder","Filter",3,"keyup"],["input",""],[1,"table-container","bg-card","shadow","rounded-2xl"],[1,"mat-elevation-z8",2,"padding","4px!important"],["mat-table","","matSort","",3,"dataSource"],["matColumnDef","cud"],["mat-header-cell","","class","cudColumnExtra ml-0 pl-12","style","padding-left: 0px!important;",4,"matHeaderCellDef"],["mat-cell","","class","cudColumnExtra ml-0 pl-12","style","padding-left: 0px!important;",4,"matCellDef"],["matColumnDef","title"],["mat-header-cell","",4,"matHeaderCellDef"],["mat-cell","","class","table-cell",4,"matCellDef"],["matColumnDef","advertPackageDescription"],["matColumnDef","avatar"],["matColumnDef","statusDescription"],["mat-header-row","",4,"matHeaderRowDef","matHeaderRowDefSticky"],["mat-row","",4,"matRowDef","matRowDefColumns"],[3,"pageSizeOptions","pageSize","disabled"],[1,"sm:col-span-2","lg:col-span-2","flex","flex-col","flex-auto","p-6","overflow-hidden",2,"padding","0!important"],["mat-header-cell","",1,"cudColumnExtra","ml-0","pl-12",2,"padding-left","0px!important"],["mat-icon-button","","color","default","matTooltip","Add Advert",3,"disabled","click"],[1,"fab-icon"],["mat-cell","",1,"cudColumnExtra","ml-0","pl-12",2,"padding-left","0px!important"],["mat-icon-button","","color","default","matTooltip","Update Advert",3,"disabled","click"],["mat-icon-button","","color","default","matTooltip","Remove Advert",3,"disabled","click"],["mat-header-cell",""],["mat-sort-header","title",1,"table-header"],["mat-cell","",1,"table-cell"],["mat-sort-header","advertPackageDescription",1,"table-header"],["mat-sort-header","avatar",1,"table-header"],["style","max-width: 80px;max-height: 80px;","class","image",3,"src",4,"ngIf"],["style","max-width: 80px;max-height: 80px;","src","assets/images/no-image.jpg","class","image",4,"ngIf"],[1,"image",2,"max-width","80px","max-height","80px",3,"src"],["src","assets/images/no-image.jpg",1,"image",2,"max-width","80px","max-height","80px"],["mat-sort-header","statusDescription",1,"table-header"],["mat-header-row",""],["mat-row",""]],template:function(a,r){1&a&&(t.TgZ(0,"div",0),t.TgZ(1,"div",1),t.TgZ(2,"div",2),t.TgZ(3,"div",3),t.TgZ(4,"mat-form-field",4),t.TgZ(5,"input",5,6),t.NdJ("keyup",function(m){return r.applyFilter(m)}),t.qZA(),t.qZA(),t.TgZ(7,"div",7),t.TgZ(8,"mat-card",8),t.TgZ(9,"table",9),t.ynx(10,10),t.YNc(11,V,4,1,"th",11),t.YNc(12,tt,7,2,"td",12),t.BQk(),t.ynx(13,13),t.YNc(14,et,3,0,"th",14),t.YNc(15,at,2,1,"td",15),t.BQk(),t.ynx(16,16),t.YNc(17,it,3,0,"th",14),t.YNc(18,nt,2,1,"td",15),t.BQk(),t.ynx(19,17),t.YNc(20,rt,3,0,"th",14),t.YNc(21,lt,3,2,"td",15),t.BQk(),t.ynx(22,18),t.YNc(23,ct,3,0,"th",14),t.YNc(24,dt,2,1,"td",15),t.BQk(),t.YNc(25,mt,1,0,"tr",19),t.YNc(26,gt,1,0,"tr",20),t.qZA(),t._UZ(27,"mat-paginator",21),t.qZA(),t.qZA(),t.qZA(),t.TgZ(28,"div",22),t._UZ(29,"advert"),t.qZA(),t.qZA(),t.qZA(),t.qZA()),2&a&&(t.xp6(9),t.Q6J("dataSource",r.dataSource),t.xp6(16),t.Q6J("matHeaderRowDef",r.displayedColumns)("matHeaderRowDefSticky",!0),t.xp6(1),t.Q6J("matRowDefColumns",r.displayedColumns),t.xp6(1),t.Q6J("pageSizeOptions",t.DdM(7,ut))("pageSize",10)("disabled",r.loading))},directives:[l.KE,A.Nt,K.a8,u.BZ,Z.YE,u.w1,u.fO,u.Dz,u.as,u.nj,v.NW,G.I,u.ge,h.lW,$.gM,X.Hw,u.ev,Z.nU,d.O5,u.XQ,u.Gk],encapsulation:2}),n})();var ft=s(7776);const ht=[{path:"",component:pt}];let vt=(()=>{class n{}return n.\u0275fac=function(a){return new(a||n)},n.\u0275mod=t.oAB({type:n}),n.\u0275inj=t.cJS({imports:[[S.Bz.forChild(ht),ft.m]]}),n})()},3098:(P,I)=>{var S=function(){function e(i){if(!i)throw new TypeError("Invalid argument; `value` has no value.");this.value=e.EMPTY,i&&e.isGuid(i)&&(this.value=i)}return e.isGuid=function(i){var v=i.toString();return i&&(i instanceof e||e.validator.test(v))},e.create=function(){return new e([e.gen(2),e.gen(1),e.gen(1),e.gen(1),e.gen(3)].join("-"))},e.createEmpty=function(){return new e("emptyguid")},e.parse=function(i){return new e(i)},e.raw=function(){return[e.gen(2),e.gen(1),e.gen(1),e.gen(1),e.gen(3)].join("-")},e.gen=function(i){for(var v="",Z=0;Z<i;Z++)v+=(65536*(1+Math.random())|0).toString(16).substring(1);return v},e.prototype.equals=function(i){return e.isGuid(i)&&this.value===i.toString()},e.prototype.isEmpty=function(){return this.value===e.EMPTY},e.prototype.toString=function(){return this.value},e.prototype.toJSON=function(){return{value:this.value}},e.validator=new RegExp("^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$","i"),e.EMPTY="00000000-0000-0000-0000-000000000000",e}();I.i=S}}]);