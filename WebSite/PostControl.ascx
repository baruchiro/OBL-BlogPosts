<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostControl.ascx.cs" Inherits="PostControl" %>
<%@ Register Src="~/UserNameControl.ascx" TagPrefix="uc1" TagName="UserNameControl" %>
<%@ Register Src="~/UserDetailsControl.ascx" TagPrefix="uc1" TagName="UserDetailsControl" %>


<div class="row">
    <uc1:usernamecontrol runat="server" id="UserNameControl" username='<%# post.User.name %>' />
    <div class="box">
        <div class="post">
            <span class="upper nomap"><%# post.title %></span>
            <p class="text nomap">
                <%# post.body %>
            </p>
            <uc1:userdetailscontrol runat="server" id="UserDetailsControl" user='<%# post.User %>' />
        </div>
    </div>
</div>
