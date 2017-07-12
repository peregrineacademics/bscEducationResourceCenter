var LogGridRow = React.createClass({
    render: function () {
        return (<tr>
            <td className="mobile visible-xs">
                <i>Review, Issue or Name:</i>&nbsp;<a href={this.props.item.linkURL} title="">{this.props.item.description}</a><br />
                <i>Source:</i>&nbsp;{this.props.item.logSourceName}<br />
                <i>Type:</i>&nbsp;{this.props.item.logTypeName}<br />
                <i>Message:</i>&nbsp;{this.props.item.message}<br />
                <i>Logged By:</i>&nbsp;{this.props.item.createdBy}<br />
                <i>Time Stamp:</i>&nbsp;{this.props.item.createdOn}<br />
            </td>
            <td className="hidden-xs"><a href={this.props.item.linkURL} title="">{this.props.item.description}</a></td>
            <td className="hidden-xs">{this.props.item.logSourceName}</td>
            <td className="hidden-xs">{this.props.item.logTypeName}</td>
            <td className="hidden-xs">{this.props.item.message}</td>
            <td className="hidden-xs">{this.props.item.createdBy}</td>
            <td className="hidden-xs">{this.props.item.createdOnString}</td>
        </tr>)
    }
});

var LogSourceSelectOption = React.createClass({
    render: function () {
        return (<option value={this.props.item.id}>{this.props.item.name}</option>)
    }
});

var LogTypeSelectOption = React.createClass({
    render: function () {
        return (<option value={this.props.item.id}>{this.props.item.name}</option>)
    }
});

var UserSelectOption = React.createClass({
    render: function () {
        return (<option value={this.props.item.id}>{this.props.item.fullName}</option>)
    }
});

var LogGridTable = React.createClass({
    getInitialState: function () {
        return {
            loading: true,
            data: {
                list: [],
                logSourceList: [],
                logTypeList: [],
                userList: [],
                totalRecord: 0,
                totalPage: 0,
                searchLogSources: '',
                searchLogTypes: '',
                searchClients: '',
                searchUsers: '',
                searchStartDate: '',
                searchEndDate: '',
                sortColumnName: '',
                sortOrder: '',
                currentPage: 1,
                pageSize: 50
            }
        }
    },

    componentDidMount: function () {
        this.populateData();
    },

    componentWillUnmount: function () {
    },

    populateData: function () {
        var params = {
            pageSize: this.state.data.pageSize,
            currentPage: this.state.data.currentPage
        }

        if (this.state.data.searchLogSources) {
            params.searchLogSources = this.state.data.searchLogSources;
        }

        if (this.state.data.searchLogTypes) {
            params.searchLogTypes = this.state.data.searchLogTypes;
        }

        if (this.state.data.searchUsers) {
            params.searchUsers = this.state.data.searchUsers;
        }

        if (this.state.data.searchStartDate) {
            params.searchStartDate = this.state.data.searchStartDate;
        }

        if (this.state.data.searchEndDate) {
            params.searchEndDate = this.state.data.searchEndDate;
        }

        if (this.state.data.sortColumnName) {
            params.sortColumnName = this.state.data.sortColumnName;
        }

        if (this.state.data.sortOrder) {
            params.sortOrder = this.state.data.sortOrder;
        }

        this.setState({
            loading: true
        });

        $.ajax({
            url: this.props.dataUrl,
            type: 'GET',
            data: params,
            success: function (data) {
                if (this.isMounted()) {
                    this.setState({
                        loading: false,
                        data: data
                    });
                }
            }.bind(this),
            error: function (err) {
                //return alert('Error: ' + err.toString());
            }.bind(this),
            complete: function (response, status) {
                //return alert("Completed: " + status);
            }.bind(this)
        });
    },

    pageChanged: function (pageNumber, e) {
        this.state.data.currentPage = pageNumber;
        this.populateData();
    },

    sortChanged: function (sortColumnName, order, e) {
        e.preventDefault();
        this.state.data.sortColumnName = sortColumnName;
        this.state.data.currentPage = 1;
        this.state.data.sortOrder = order.toString().toLowerCase() == 'asc' ? 'desc' : 'asc';
        this.populateData();
    },

    searchChanged: function (e) {
        e.preventDefault();
        this.state.data.currentPage = 1;
        this.state.data.sortColumnName = "CreatedOn";
        this.state.data.sortOrder = "desc";
        this.state.data.searchLogSources = $(this.refs.selectMultipleLogSources).select2('val').toString();
        this.state.data.searchLogTypes = $(this.refs.selectMultipleLogTypes).select2('val').toString();
        this.state.data.searchUsers = $(this.refs.selectMultipleUsers).select2('val').toString();
        this.state.data.searchStartDate = document.getElementById("inputStartDate").value.trim();
        this.state.data.searchEndDate = document.getElementById("inputEndDate").value.trim();

        this.populateData();
    },

    resetChanged: function (e) {
        e.preventDefault();
        this.state.data.currentPage = 1;
        this.state.data.sortColumnName = "CreatedOn";
        this.state.data.sortOrder = "desc";
        this.state.data.searchLogSources = '';
        this.state.data.searchLogTypes = '';
        this.state.data.searchUsers = '';
        this.state.data.searchStartDate = '';
        this.state.data.searchEndDate = '';
        this.populateData();

        $(this.refs.selectMultipleLogSources).select2('val', null);
        $(this.refs.selectMultipleLogTypes).select2('val', null);
        $(this.refs.selectMultipleUsers).select2('val', null);

        document.getElementById("inputStartDate").value = '';
        document.getElementById("inputEndDate").value = '';
    },

    render: function () {
        var logSources = [];
        this.state.data.logSourceList.forEach(function (item) {
            logSources.push(
                <LogSourceSelectOption key={item.id} item={item} />);
        });

        var logTypes = [];
        this.state.data.logTypeList.forEach(function (item) {
            logTypes.push(
                <LogTypeSelectOption key={item.id} item={item} />);
        });

        var users = [];
        this.state.data.userList.forEach(function (item) {
            users.push(
                <UserSelectOption key={item.id} item={item} />);
        });

        var rows = [];
        this.state.data.list.forEach(function (item) {
            rows.push(
                <LogGridRow key={item.id} item={item} />);
        });

        return (<div>
            {/* Filter Section */}
            <div id="gridsearch-filter" className="panel panel-default collapsable">
                <div className="panel-heading">
                    <a data-toggle="collapse" data-parent="#gridsearch-filter" data-animate="true"
                        href="#gridsearch-fields" style={{ color: 'inherit' }}>
                        <i className="fa fa-angle-down toggler"></i>
                        &nbsp;Filter results using the criteria below
                    </a>
                </div>
                <div id="gridsearch-fields" className="panel-body fields collapse in">
                    <div>
                        <div className="row">
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div className="input-group">
                                    <input id="inputStartDate" className="form-control" ref="inputStartDate" placeholder="Start Date" />
                                    <span className="input-group-addon"><i className="fa fa-calendar"></i></span>
                                </div>
                            </div>
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div className="input-group">
                                    <input id="inputEndDate" className="form-control" ref="inputEndDate" placeholder="End Date" />
                                    <span className="input-group-addon"><i className="fa fa-calendar"></i></span>
                                </div>
                            </div>
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                            </div>
                        </div>
                    </div>
                    <div style={{ marginTop: '5px' }}>
                        <div className="row">
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div className="input-group">
                                    <select id="selectMultipleLogSources" ref="selectMultipleLogSources" multiple className="select2" placeholder="Log Source">
                                        {logSources}
                                    </select>
                                    <span className="input-group-addon"><i className="fa fa-file-text-o"></i></span>
                                </div>
                            </div>
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div className="input-group">
                                    <select id="selectMultipleLogTypes" ref="selectMultipleLogTypes" multiple className="select2" placeholder="Log Type">
                                        {logTypes}
                                    </select>
                                    <span className="input-group-addon"><i className="fa fa-file-text-o"></i></span>
                                </div>
                            </div>
                            <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div className="input-group">
                                    <select id="selectMultipleUsers" ref="selectMultipleUsers" multiple className="select2" placeholder="User or Logged By">
                                        {users}
                                    </select>
                                    <span className="input-group-addon"><i className="fa fa-users"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style={{ marginTop: '5px' }}>
                        <div className="row">
                            <div className="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <i style={{ fontSize: '11px' }}>Note: Only the logs dated a month ago up to today's date are shown by default if the start and end dates are not specified.</i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Button Section */}
            <div>
                {this.state.loading ?
                    <div className="pull-left">
                        <div>
                            &nbsp;&nbsp;Loading, Please wait...
                                </div>
                    </div>
                    :
                    <div style={{ marginTop: '-20px' }}>

                        {/* Download Section */}
                        <div className="btn-group pull-right hidden-xs">
                            <div style={{ marginTop: '18px' }}>
                                <button className="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">
                                    <i className="fa fa-cog"></i>
                                    &nbsp;
                                            <span className="caret"></span>
                                </button>
                                <ul className="dropdown-menu pull-right">
                                    <li>
                                        <a href={'/Admin/ExportLogsToExcel?' +
                                            'searchLogSources=' + (this.state.data.searchLogSources == null ? '' : this.state.data.searchLogSources) +
                                            '&searchLogTypes=' + (this.state.data.searchLogTypes == null ? '' : this.state.data.searchLogTypes) +
                                            '&searchUsers=' + (this.state.data.searchUsers == null ? '' : this.state.data.searchUsers) +
                                            '&searchStartDate=' + (this.state.data.searchStartDate == null ? '' : this.state.data.searchStartDate) +
                                            '&searchEndDate=' + (this.state.data.searchEndDate == null ? '' : this.state.data.searchEndDate)}>
                                            <i className="fa fa-download"></i>&nbsp;Download all <span></span> Results to MS Excel
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        {/* Search and Reset */}
                        <div className="pull-right">
                            <div style={{ marginTop: '18px' }}>
                                <button id="buttonSearch" className="btn btn-primary" onClick={this.searchChanged}>
                                    <span className="hidden-xs">Search</span>
                                    <span className="visible-xs"><i className="fa fa-search"></i>&nbsp;Search</span>
                                </button>
                                &nbsp;
                                        <button className="btn btn-default" onClick={this.resetChanged}>
                                    <span className="hidden-xs">Reset</span>
                                    <span className="visible-xs"><i className="fa fa-undo"></i></span>
                                </button>
                                &nbsp;
                            </div>
                        </div>

                        {/* Paging */}
                        <GridPager Size={this.state.data.totalPage} onPageChanged={this.pageChanged} currentPage={this.state.data.currentPage} totalRecord={this.state.data.totalRecord} />

                    </div>
                }
            </div>

            {/* Data Table */}
            <div>
                {this.state.loading ? <div></div> :
                    <div>
                        {this.state.data.totalRecord == 0 ?
                            <div><div style={{ color: 'Red' }}><h6><strong><em><br />No results were returned.</em></strong></h6></div></div>
                            :
                            <table id="tableLogs" className="table table-hover table-condensed pre-scrollable gridview">
                                <thead>
                                    <tr>
                                        <th className="mobile visible-xs">
                                            <div className="btn-group">
                                                <button type="button" className="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown" style={{ textAlign: 'left' }}>
                                                    Sort By <span className="caret"></span>
                                                </button>
                                                <ul className="dropdown-menu">
                                                    <li data-header="Description"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'Description', this.state.data.sortOrder)}>Review, Issue or Name</a></li>
                                                    <li data-header="LogSourceName"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'LogSourceName', this.state.data.sortOrder)}>Source</a></li>
                                                    <li data-header="LogTypeName"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'LogTypeName', this.state.data.sortOrder)}>Type</a></li>
                                                    <li data-header="Message"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'Message', this.state.data.sortOrder)}>Message</a></li>
                                                    <li data-header="CreatedBy"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'CreatedBy', this.state.data.sortOrder)}>Logged By</a></li>
                                                    <li data-header="CreatedOn"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'CreatedOn', this.state.data.sortOrder)}>Time Stamp</a></li>
                                                </ul>
                                            </div>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'Description', this.state.data.sortOrder)}>Review, Issue or Name</a>
                                        </th>
                                        <th className="hidden-xs" style={{ width: '200px' }}>
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'LogSourceName', this.state.data.sortOrder)}>Source</a>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'LogTypeName', this.state.data.sortOrder)}>Type</a>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'Message', this.state.data.sortOrder)}>Message</a>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'CreatedBy', this.state.data.sortOrder)}>Logged By</a>
                                        </th>
                                        <th className="hidden-xs" style={{ width: '160px' }}>
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'CreatedOn', this.state.data.sortOrder)}>Time Stamp</a>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>{rows}</tbody>
                            </table>
                        }
                    </div>
                }
            </div>
        </div>)
    }
});

ReactDOM.render(<LogGridTable dataUrl="/admin/listlogs" />, document.getElementById('divgriddata'));