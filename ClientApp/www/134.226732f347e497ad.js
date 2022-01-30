"use strict";(self.webpackChunkloadgistix=self.webpackChunkloadgistix||[]).push([[134],{8134:(S,c,r)=>{r.r(c),r.d(c,{AuthResetPasswordModule:()=>E});var l=r(4521),p=r(7423),u=r(7322),f=r(5245),h=r(7531),g=r(773),w=r(6236),A=r(7775),Z=r(7776),d=r(3075),P=r(8746),y=r(8288);class v{static isEmptyInputValue(o){return null==o||0===o.length}static mustMatch(o,e){return n=>{const a=n.get(o),i=n.get(e);if(!a||!i||(i.hasError("mustMatch")&&(delete i.errors.mustMatch,i.updateValueAndValidity()),this.isEmptyInputValue(i.value)||a.value===i.value))return null;const m={mustMatch:!0};return i.setErrors(m),m}}}var t=r(5e3),x=r(8951),C=r(9808),T=r(2494);const I=["resetPasswordNgForm"];function R(s,o){if(1&s&&(t.TgZ(0,"fuse-alert",22),t._uU(1),t.qZA()),2&s){const e=t.oxw();t.Q6J("appearance","outline")("showIcon",!1)("type",e.alert.type)("@shake","error"===e.alert.type),t.xp6(1),t.hij(" ",e.alert.message," ")}}function J(s,o){1&s&&t._UZ(0,"mat-icon",23),2&s&&t.Q6J("svgIcon","heroicons_solid:eye")}function F(s,o){1&s&&t._UZ(0,"mat-icon",23),2&s&&t.Q6J("svgIcon","heroicons_solid:eye-off")}function N(s,o){1&s&&t._UZ(0,"mat-icon",23),2&s&&t.Q6J("svgIcon","heroicons_solid:eye")}function Q(s,o){1&s&&t._UZ(0,"mat-icon",23),2&s&&t.Q6J("svgIcon","heroicons_solid:eye-off")}function U(s,o){1&s&&(t.TgZ(0,"mat-error"),t._uU(1," Password confirmation is required "),t.qZA())}function M(s,o){1&s&&(t.TgZ(0,"mat-error"),t._uU(1," Passwords must match "),t.qZA())}function b(s,o){1&s&&(t.TgZ(0,"span"),t._uU(1," Reset your password "),t.qZA())}function Y(s,o){1&s&&t._UZ(0,"mat-progress-spinner",24),2&s&&t.Q6J("diameter",24)("mode","indeterminate")}const _=function(){return["/sign-in"]},q=[{path:"",component:(()=>{class s{constructor(e,n,a){this._authService=e,this._formBuilder=n,this.route=a,this.alert={type:"success",message:""},this.showAlert=!1}ngOnInit(){this.route.queryParams.subscribe(e=>{this.id=e.id}),this.resetPasswordForm=this._formBuilder.group({password:["",d.kI.required],passwordConfirm:["",d.kI.required]},{validators:v.mustMatch("password","passwordConfirm")}),setTimeout(()=>{console.log(this.id)},100)}resetPassword(){this.resetPasswordForm.invalid||(this.resetPasswordForm.disable(),this.showAlert=!1,this._authService.resetPassword(this.id,this.resetPasswordForm.get("password").value).pipe((0,P.x)(()=>{this.resetPasswordForm.enable(),this.resetPasswordNgForm.resetForm(),this.showAlert=!0})).subscribe(e=>{this.alert={type:"success",message:"Your password has been reset."}},e=>{this.alert={type:"error",message:"Something went wrong, please try again."}}))}}return s.\u0275fac=function(e){return new(e||s)(t.Y36(x.e),t.Y36(d.qu),t.Y36(l.gz))},s.\u0275cmp=t.Xpm({type:s,selectors:[["auth-reset-password"]],viewQuery:function(e,n){if(1&e&&t.Gf(I,5),2&e){let a;t.iGM(a=t.CRH())&&(n.resetPasswordNgForm=a.first)}},decls:40,vars:16,consts:[[1,"flex","flex-col","flex-auto","items-center","sm:justify-center","min-w-0"],[1,"w-full","sm:w-auto","py-8","px-4","sm:p-12","sm:rounded-2xl","sm:shadow","sm:bg-card"],[1,"w-full","max-w-80","sm:w-80","mx-auto","sm:mx-0"],[1,"w-100-p"],["src","assets/images/logo/loadgistix.png"],[1,"mt-8","text-4xl","font-extrabold","tracking-tight","leading-tight"],[1,"mt-0.5","font-medium"],["class","mt-8 -mb-4",3,"appearance","showIcon","type",4,"ngIf"],[1,"mt-8",3,"formGroup"],["resetPasswordNgForm","ngForm"],[1,"w-full"],["id","password","matInput","","type","password",3,"formControlName"],["passwordField",""],["mat-icon-button","","type","button","matSuffix","",3,"click"],["class","icon-size-5",3,"svgIcon",4,"ngIf"],["id","password-confirm","matInput","","type","password",3,"formControlName"],["passwordConfirmField",""],[4,"ngIf"],["mat-flat-button","",1,"fuse-mat-button-large","w-full","mt-3",3,"color","disabled","click"],[3,"diameter","mode",4,"ngIf"],[1,"mt-8","text-md","font-medium","text-secondary"],[1,"ml-1","text-primary-500","hover:underline",3,"routerLink"],[1,"mt-8","-mb-4",3,"appearance","showIcon","type"],[1,"icon-size-5",3,"svgIcon"],[3,"diameter","mode"]],template:function(e,n){if(1&e){const a=t.EpF();t.TgZ(0,"div",0),t.TgZ(1,"div",1),t.TgZ(2,"div",2),t.TgZ(3,"div",3),t._UZ(4,"img",4),t.qZA(),t.TgZ(5,"div",5),t._uU(6,"Reset your password"),t.qZA(),t.TgZ(7,"div",6),t._uU(8,"Create a new password for your account"),t.qZA(),t.YNc(9,R,2,5,"fuse-alert",7),t.TgZ(10,"form",8,9),t.TgZ(12,"mat-form-field",10),t.TgZ(13,"mat-label"),t._uU(14,"Password"),t.qZA(),t._UZ(15,"input",11,12),t.TgZ(17,"button",13),t.NdJ("click",function(){t.CHM(a);const m=t.MAs(16);return m.type="password"===m.type?"text":"password"}),t.YNc(18,J,1,1,"mat-icon",14),t.YNc(19,F,1,1,"mat-icon",14),t.qZA(),t.TgZ(20,"mat-error"),t._uU(21," Password is required "),t.qZA(),t.qZA(),t.TgZ(22,"mat-form-field",10),t.TgZ(23,"mat-label"),t._uU(24,"Password (Confirm)"),t.qZA(),t._UZ(25,"input",15,16),t.TgZ(27,"button",13),t.NdJ("click",function(){t.CHM(a);const m=t.MAs(26);return m.type="password"===m.type?"text":"password"}),t.YNc(28,N,1,1,"mat-icon",14),t.YNc(29,Q,1,1,"mat-icon",14),t.qZA(),t.YNc(30,U,2,0,"mat-error",17),t.YNc(31,M,2,0,"mat-error",17),t.qZA(),t.TgZ(32,"button",18),t.NdJ("click",function(){return n.resetPassword()}),t.YNc(33,b,2,0,"span",17),t.YNc(34,Y,1,2,"mat-progress-spinner",19),t.qZA(),t.TgZ(35,"div",20),t.TgZ(36,"span"),t._uU(37,"Return to"),t.qZA(),t.TgZ(38,"a",21),t._uU(39,"sign in "),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA()}if(2&e){const a=t.MAs(16),i=t.MAs(26);t.xp6(9),t.Q6J("ngIf",n.showAlert),t.xp6(1),t.Q6J("formGroup",n.resetPasswordForm),t.xp6(5),t.Q6J("formControlName","password"),t.xp6(3),t.Q6J("ngIf","password"===a.type),t.xp6(1),t.Q6J("ngIf","text"===a.type),t.xp6(6),t.Q6J("formControlName","passwordConfirm"),t.xp6(3),t.Q6J("ngIf","password"===i.type),t.xp6(1),t.Q6J("ngIf","text"===i.type),t.xp6(1),t.Q6J("ngIf",n.resetPasswordForm.get("passwordConfirm").hasError("required")),t.xp6(1),t.Q6J("ngIf",n.resetPasswordForm.get("passwordConfirm").hasError("mustMatch")),t.xp6(1),t.Q6J("color","primary")("disabled",n.resetPasswordForm.disabled),t.xp6(1),t.Q6J("ngIf",!n.resetPasswordForm.disabled),t.xp6(1),t.Q6J("ngIf",n.resetPasswordForm.disabled),t.xp6(4),t.Q6J("routerLink",t.DdM(15,_))}},directives:[C.O5,d._Y,d.JL,d.sg,u.KE,u.hX,h.Nt,d.Fj,d.JJ,d.u,p.lW,u.R9,u.TO,l.yS,T.W,f.Hw,g.Ou],encapsulation:2,data:{animation:y.L}}),s})()}];let E=(()=>{class s{}return s.\u0275fac=function(e){return new(e||s)},s.\u0275mod=t.oAB({type:s}),s.\u0275inj=t.cJS({imports:[[l.Bz.forChild(q),p.ot,u.lN,f.Ps,h.c,g.Cq,w.J,A.fC,Z.m]]}),s})()}}]);