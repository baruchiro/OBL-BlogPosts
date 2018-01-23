<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserDetailsControl.ascx.cs" Inherits="UserDetailsControl" %>
<div class="details nomap">
    <div>Phone: <%# this.user.phone %></div>
    <div>Zipcode: <%# this.user.zipcode %></div>
</div>
<div class="map <%# "user"+user.Id %>"
    data-lng='<%# this.user.lng %>'
    data-lat='<%# this.user.lat %>'>
    map
</div>
<script>
    
</script>
