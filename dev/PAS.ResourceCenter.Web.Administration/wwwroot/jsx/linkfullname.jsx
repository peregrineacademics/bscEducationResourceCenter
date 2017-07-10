var LinkFullName = React.createClass({
    getInitialState: function () {
        return { data: [] };
    },

    componentDidMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.dataUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },

    render: function () {
        return (<div className="login-info">
            <span>
                <a id="show-shortcut" href="#" data-action="toggleShortcut">
                    <img alt="" src="/img/avatars/male.png" />
                    <span>&nbsp;{this.state.data.fullName}&nbsp;&nbsp;</span>
                    <i className="fa fa-angle-down" />
                </a>
            </span>
        </div>);
    }
});

ReactDOM.render(<LinkFullName dataUrl="/account/fullname" />, document.getElementById('divcurrentuser'));
