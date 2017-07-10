var UserGridRow = React.createClass({
    render: function () {
        return (<tr>
            <td className="mobile visible-xs">
                <div className="btn-group">
                    <a href={'/Users/Edit?Id=' + this.props.item.id.toString()}><i className="btn btn-default fa fa-file-text-o" />&nbsp;</a>
                </div>
            </td>
            <td className="mobile visible-xs">
                <i>Role:</i>&nbsp;{this.props.item.roleName}<br />
                <i>Name:</i>&nbsp;{this.props.item.fullName}<br />
                <i>Email:</i>&nbsp;{this.props.item.email}<br />
                <i>Created:</i>&nbsp;{this.props.item.created}<br />
                <i>Enabled:</i>&nbsp;{this.props.item.enabled ? 'Yes' : 'No'}
            </td>
            <td className="hidden-xs">
                <div className="btn-group @css_position">
                    <a href={'/Users/Edit?Id=' + this.props.item.id.toString()} className="btn btn-default btn-xs" style={{ width: 50 }}>View</a>
                </div>
            </td>
            <td className="hidden-xs">{this.props.item.roleName}</td>
            <td className="hidden-xs">{this.props.item.fullName}</td>
            <td className="hidden-xs">{this.props.item.email}</td>
            <td className="hidden-xs">{this.props.item.created}</td>
            <td className="hidden-xs" style={{ textAlign: 'center' }}>
                {this.props.item.enabled ? <i className="fa fa-check" style={{ color: 'green' }} /> : <i className="fa fa-remove" style={{ color: 'lightgray' }} />}
            </td>
        </tr>)
    }
});

var ClientSelectOption = React.createClass({
    render: function () {
        return (<option value={this.props.item.id}>{this.props.item.name}</option>)
    }
});

var UserGridTable = React.createClass({
    getInitialState: function () {
        return {
            loading: true,
            data: {
                list: [],
                totalRecord: 0,
                totalPage: 0,
                searchRoles: '',
                searchClients: '',
                searchName: '',
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

        if (this.state.data.searchRoles) {
            params.searchRoles = this.state.data.searchRoles;
        }

        if (this.state.data.searchClients) {
            params.searchClients = this.state.data.searchClients;
        }

        if (this.state.data.searchName) {
            params.searchName = this.state.data.searchName;
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
        this.state.data.sortColumnName = "FullName";
        this.state.data.sortOrder = "asc";
        this.state.data.searchRoles = $(this.refs.selectMultipleRoles).select2('val').toString();
        this.state.data.searchName = document.getElementById("inputSearchName").value.trim();

        this.populateData();
    },

    resetChanged: function (e) {
        e.preventDefault();
        this.state.data.currentPage = 1;
        this.state.data.sortColumnName = "FullName";
        this.state.data.sortOrder = "asc";
        this.state.data.searchRoles = '';
        this.state.data.searchClients = '';
        this.state.data.searchName = '';
        this.populateData();

        $(this.refs.selectMultipleRoles).select2('val', null);
        $(this.refs.selectMultipleClients).select2('val', null);

        document.getElementById("inputSearchName").value = '';
    },

    render: function () {
        var rows = [];
        this.state.data.list.forEach(function (item) {
            rows.push(
                <UserGridRow key={item.id} item={item} />);
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
                    <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <div className="input-group">
                            <select id="selectMultipleRoles" ref="selectMultipleRoles" multiple className="select2" placeholder="Role">
                                <option value="learner">Learner</option>
                                <option value="faculty">Faculty</option>
                                <option value="facultyadministrator">Faculty Admin</option>
                                <option value="reviewer">Reviewer</option>
                                <option value="editor">Editor</option>
                                <option value="pasreadonlyuser">Read Only</option>
                                <option value="pasadministrator">PAS Admin</option>
                            </select>
                            <span className="input-group-addon"><i className="fa fa-users"></i></span>
                        </div>
                    </div>
                    <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <input id="inputSearchName" className="form-control" ref="inputSearchName" type="search" placeholder="Search by Name or Email" />
                    </div>
                    <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
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
                                        <a href={'/Users/ExportToExcel?searchName=' + (this.state.data.searchName == null ? '' : this.state.data.searchName) +
                                            '&searchRoles=' + (this.state.data.searchRoles == null ? '' : this.state.data.searchRoles)}>
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
                            <table className="table table-hover table-condensed pre-scrollable gridview">
                                <thead>
                                    <tr>
                                        <th className="mobile visible-xs" style={{ width: '35px' }}></th>
                                        <th className="mobile visible-xs">
                                            <div className="btn-group">
                                                <button type="button" className="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown" style={{ textAlign: 'left' }}>
                                                    Sort By <span className="caret"></span>
                                                </button>
                                                <ul className="dropdown-menu">
                                                    <li data-header="RoleName"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'RoleName', this.state.data.sortOrder)}>Role</a></li>
                                                    <li data-header="FullName"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'FullName', this.state.data.sortOrder)}>Name</a></li>
                                                    <li data-header="Email"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'Email', this.state.data.sortOrder)}>Email</a></li>
                                                    <li data-header="Created"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'Created', this.state.data.sortOrder)}>Created</a></li>
                                                    <li data-header="Enabled"><a style={{ textAlign: 'left' }} href="javascript:;" onClick={this.sortChanged.bind(this, 'Enabled', this.state.data.sortOrder)}>Enabled</a></li>
                                                </ul>
                                            </div>
                                        </th>
                                        <th className="hidden-xs" style={{ width: '50px' }}></th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'RoleName', this.state.data.sortOrder)}>Role</a>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'FullName', this.state.data.sortOrder)}>Name</a>
                                        </th>
                                        <th className="hidden-xs">
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'Email', this.state.data.sortOrder)}>Email</a>
                                        </th>
                                        <th className="hidden-xs" style={{ width: '150px' }}>
                                            <a href="javascript:;" onClick={this.sortChanged.bind(this, 'Created', this.state.data.sortOrder)}>Created</a>
                                        </th>
                                        <th className="hidden-xs" style={{ textAlign: 'center', width: '15px' }}><a href="javascript:;" onClick={this.sortChanged.bind(this, 'Enabled', this.state.data.sortOrder)}>Enabled</a></th>
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

ReactDOM.render(<UserGridTable dataUrl="/users/list" />, document.getElementById('divgriddata'));